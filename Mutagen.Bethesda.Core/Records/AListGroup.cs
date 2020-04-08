﻿using Ionic.Zlib;
using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda
{
    public abstract class AListGroup
    {
        public class GroupListOverlay<T> : IReadOnlyList<T>
        {
            private readonly IReadOnlyList<int> _locs;
            private readonly ReadOnlyMemorySlice<byte> _data;
            private readonly BinaryOverlayFactoryPackage _package;

            public int Count => _locs.Count;

            public T this[int index] => ConstructWrapper(_locs[index]);

            public GroupListOverlay(
                IReadOnlyList<int> locs,
                ReadOnlyMemorySlice<byte> data,
                BinaryOverlayFactoryPackage package)
            {
                this._locs = locs;
                this._data = data;
                this._package = package;
            }

            private T ConstructWrapper(int pos)
            {
                ReadOnlyMemorySlice<byte> slice = this._data.Slice(pos);
                var majorMeta = _package.Meta.MajorRecord(slice);
                if (majorMeta.IsCompressed)
                {
                    uint uncompressedLength = BinaryPrimitives.ReadUInt32LittleEndian(slice.Slice(majorMeta.HeaderLength));
                    byte[] buf = new byte[majorMeta.HeaderLength + checked((int)uncompressedLength)];
                    // Copy major meta bytes over
                    slice.Span.Slice(0, majorMeta.HeaderLength).CopyTo(buf.AsSpan());
                    // Set length bytes
                    BinaryPrimitives.WriteUInt32LittleEndian(buf.AsSpan().Slice(Constants.HeaderLength), uncompressedLength);
                    // Remove compression flag
                    BinaryPrimitives.WriteInt32LittleEndian(buf.AsSpan().Slice(_package.Meta.MajorConstants.FlagLocationOffset), majorMeta.MajorRecordFlags & ~Constants.CompressedFlag);
                    // Copy uncompressed data over
                    using (var stream = new ZlibStream(new ByteMemorySliceStream(slice.Slice(majorMeta.HeaderLength + 4)), CompressionMode.Decompress))
                    {
                        stream.Read(buf, majorMeta.HeaderLength, checked((int)uncompressedLength));
                    }
                    slice = new MemorySlice<byte>(buf);
                }
                return LoquiBinaryOverlayTranslation<T>.Create(
                   stream: new BinaryMemoryReadStream(slice),
                   package: _package,
                   recordTypeConverter: null);
            }

            public static GroupListOverlay<T> Factory(
                IBinaryReadStream stream,
                ReadOnlyMemorySlice<byte> data,
                BinaryOverlayFactoryPackage package,
                ObjectType objectType,
                int offset)
            {
                List<int> locations = new List<int>();

                stream.Position -= package.Meta.GroupConstants.HeaderLength;
                var groupMeta = package.Meta.GetGroup(stream);
                var finalPos = stream.Position + groupMeta.TotalLength;
                stream.Position += package.Meta.GroupConstants.HeaderLength;
                // Parse locations
                while (stream.Position < finalPos)
                {
                    VariableHeader meta = package.Meta.Constants(objectType).VariableMeta(stream.RemainingSpan);
                    locations.Add(checked((int)stream.Position - offset));
                    stream.Position += checked((int)meta.TotalLength);
                }

                return new GroupListOverlay<T>(
                    locations,
                    data,
                    package);
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (var loc in _locs)
                {
                    yield return ConstructWrapper(loc);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}