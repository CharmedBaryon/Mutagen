﻿using Mutagen.Bethesda.Internals;
using Noggog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Binary
{
    public abstract class BinaryOverlaySetList<T>
    {
        public static IReadOnlyList<T> FactoryByArray(
            ReadOnlyMemorySlice<byte> mem,
            BinaryOverlayFactoryPackage package,
            BinaryOverlay.SpanFactory<T> getter,
            int[] locs)
        {
            return new BinaryOverlayListByLocationArray(
                mem,
                package,
                getter,
                locs);
        }

        public static IReadOnlyList<T> FactoryByArray(
            ReadOnlyMemorySlice<byte> mem,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter,
            BinaryOverlay.SpanRecordFactory<T> getter,
            int[] locs)
        {
            return new BinaryOverlayRecordListByLocationArray(
                mem,
                package,
                recordTypeConverter,
                getter,
                locs);
        }

        public static IReadOnlyList<T> FactoryByStartIndex(
            ReadOnlyMemorySlice<byte> mem,
            BinaryOverlayFactoryPackage package,
            int itemLength,
            BinaryOverlay.SpanFactory<T> getter)
        {
            return new BinaryOverlayListByStartIndex(
                mem,
                package,
                getter,
                itemLength);
        }

        public static IReadOnlyList<T> FactoryByCount(
            ReadOnlyMemorySlice<byte> mem,
            BinaryOverlayFactoryPackage package,
            RecordType subrecordType,
            int itemLength,
            uint count,
            BinaryOverlay.SpanFactory<T> getter)
        {
            if ((mem.Length / (itemLength + package.Meta.SubConstants.HeaderLength)) != count)
            {
                throw new ArgumentException("Item count and expected size did not match.");
            }
            return new BinaryOverlayListByStartIndexWithRecord(
                mem,
                package,
                getter,
                itemLength,
                subrecordType);
        }

        public static IReadOnlyList<T> FactoryByCount(
            ReadOnlyMemorySlice<byte> mem,
            BinaryOverlayFactoryPackage package,
            int itemLength,
            uint count,
            BinaryOverlay.SpanFactory<T> getter)
        {
            if ((mem.Length / itemLength) != count)
            {
                throw new ArgumentException("Item count and expected size did not match.");
            }
            return new BinaryOverlayListByStartIndex(
                mem,
                package,
                getter,
                itemLength);
        }

        public static IReadOnlyList<T> FactoryByLazyParse(
            ReadOnlyMemorySlice<byte> mem,
            BinaryOverlayFactoryPackage package,
            BinaryOverlay.Factory<T> getter)
        {
            return new BinaryOverlayLazyList(
                mem,
                package,
                (m, p) =>
                {
                    var ret = new List<T>();
                    using (var stream = new BinaryMemoryReadStream(m))
                    {
                        while (!stream.Complete)
                        {
                            ret.Add(getter(stream, p));
                        }
                    }
                    return ret;
                });
        }

        public static IReadOnlyList<T> FactoryByLazyParse(
            ReadOnlyMemorySlice<byte> mem,
            BinaryOverlayFactoryPackage package,
            Func<ReadOnlyMemorySlice<byte>, BinaryOverlayFactoryPackage, IReadOnlyList<T>> getter)
        {
            return new BinaryOverlayLazyList(
                mem,
                package,
                getter);
        }

        private class BinaryOverlayListByLocationArray : IReadOnlyList<T>
        {
            private int[] _locations;
            BinaryOverlayFactoryPackage _package;
            private ReadOnlyMemorySlice<byte> _mem;
            private BinaryOverlay.SpanFactory<T> _getter;

            public BinaryOverlayListByLocationArray(
                ReadOnlyMemorySlice<byte> mem,
                BinaryOverlayFactoryPackage package,
                BinaryOverlay.SpanFactory<T> getter,
                int[] locs)
            {
                this._mem = mem;
                this._getter = getter;
                this._package = package;
                this._locations = locs;
            }

            public T this[int index] => _getter(_mem.Slice(_locations[index]), _package);

            public int Count => _locations.Length;

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < _locations.Length; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        private class BinaryOverlayRecordListByLocationArray : IReadOnlyList<T>
        {
            private int[] _locations;
            private BinaryOverlayFactoryPackage _package;
            private ReadOnlyMemorySlice<byte> _mem;
            private BinaryOverlay.SpanRecordFactory<T> _getter;
            private RecordTypeConverter? _recordTypeConverter;

            public BinaryOverlayRecordListByLocationArray(
                ReadOnlyMemorySlice<byte> mem,
                BinaryOverlayFactoryPackage package,
                RecordTypeConverter? recordTypeConverter,
                BinaryOverlay.SpanRecordFactory<T> getter,
                int[] locs)
            {
                this._mem = mem;
                this._getter = getter;
                this._package = package;
                this._recordTypeConverter = recordTypeConverter;
                this._locations = locs;
            }

            public T this[int index] => _getter(_mem.Slice(_locations[index]), _package, _recordTypeConverter);

            public int Count => _locations.Length;

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < _locations.Length; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        public class BinaryOverlayListByStartIndex : IReadOnlyList<T>
        {
            private readonly int _itemLength;
            private readonly BinaryOverlayFactoryPackage _package;
            private readonly ReadOnlyMemorySlice<byte> _mem;
            private readonly BinaryOverlay.SpanFactory<T> _getter;

            public BinaryOverlayListByStartIndex(
                ReadOnlyMemorySlice<byte> mem,
                BinaryOverlayFactoryPackage package,
                BinaryOverlay.SpanFactory<T> getter,
                int itemLength)
            {
                this._mem = mem;
                this._package = package;
                this._getter = getter;
                this._itemLength = itemLength;
            }

            public T this[int index]
            {
                get
                {
                    var startIndex = index * _itemLength;
                    return _getter(_mem.Slice(startIndex, _itemLength), _package);
                }
            }

            public int Count => this._mem.Length / _itemLength;

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        public class BinaryOverlayListByStartIndexWithRecord : IReadOnlyList<T>
        {
            private readonly int _itemLength;
            private readonly BinaryOverlayFactoryPackage _package;
            private readonly ReadOnlyMemorySlice<byte> _mem;
            private readonly BinaryOverlay.SpanFactory<T> _getter;
            private readonly RecordType _recordType;
            private readonly int _totalItemLength;

            public BinaryOverlayListByStartIndexWithRecord(
                ReadOnlyMemorySlice<byte> mem,
                BinaryOverlayFactoryPackage package,
                BinaryOverlay.SpanFactory<T> getter,
                int itemLength,
                RecordType recordType)
            {
                this._mem = mem;
                this._package = package;
                this._getter = getter;
                this._itemLength = itemLength;
                this._recordType = recordType;
                this._totalItemLength = itemLength + this._package.Meta.SubConstants.HeaderLength;
            }

            public T this[int index]
            {
                get
                {
                    var startIndex = index * this._totalItemLength;
                    var subMeta = _package.Meta.Subrecord(_mem.Slice(startIndex));
                    if (subMeta.RecordType != this._recordType)
                    {
                        throw new ArgumentException($"Unexpected record type: {subMeta.RecordType} != {this._recordType}");
                    }
                    if (subMeta.ContentLength != this._itemLength)
                    {
                        throw new ArgumentException($"Unexpected record length: {subMeta.ContentLength} != {this._itemLength}");
                    }
                    return _getter(_mem.Slice(startIndex + _package.Meta.SubConstants.HeaderLength, _itemLength), _package);
                }
            }

            public int Count => this._mem.Length / this._totalItemLength;

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        public class BinaryOverlayLazyList : IReadOnlyList<T>
        {
            private readonly Lazy<IReadOnlyList<T>> _list;
            private readonly ReadOnlyMemorySlice<byte> _mem;
            private readonly BinaryOverlayFactoryPackage _package;
            private readonly Func<ReadOnlyMemorySlice<byte>, BinaryOverlayFactoryPackage, IReadOnlyList<T>> _getter;

            public BinaryOverlayLazyList(
                ReadOnlyMemorySlice<byte> mem,
                BinaryOverlayFactoryPackage package,
                Func<ReadOnlyMemorySlice<byte>, BinaryOverlayFactoryPackage, IReadOnlyList<T>> getter)
            {
                this._mem = mem;
                this._getter = getter;
                this._package = package;
                this._list = new Lazy<IReadOnlyList<T>>(ConstructList, isThreadSafe: true);
            }

            private IReadOnlyList<T> ConstructList()
            {
                return this._getter(_mem, _package);
            }

            public T this[int index] => this._list.Value[index];

            public int Count => this._list.Value.Count;

            public IEnumerator<T> GetEnumerator() => this._list.Value.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}