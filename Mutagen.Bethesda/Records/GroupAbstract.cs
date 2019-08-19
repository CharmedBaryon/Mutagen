﻿using DynamicData;
using Ionic.Zlib;
using Loqui;
using Loqui.Xml;
using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mutagen.Bethesda
{
    public abstract class GroupAbstract<T> : LoquiNotifyingObject, IEnumerable<T>, IGroupCommon<T>
        where T : IMajorRecordInternal, IXmlItem, IBinaryItem
    {
        protected abstract IObservableCache<T, FormKey> InternalItems { get; }

        private Lazy<IObservableCache<T, string>> _editorIDCache;
        public IObservableCache<T, string> ByEditorID => _editorIDCache.Value;

        public IMod SourceMod { get; private set; }

        protected GroupAbstract()
        {
        }

        public GroupAbstract(IModGetter getter)
        {
        }

        public GroupAbstract(IMod mod)
        {
            this.SourceMod = mod;
            this.Init();
        }

        private void Init()
        {
            _editorIDCache = new Lazy<IObservableCache<T, string>>(() =>
            {
                return this.InternalItems.Connect()
                    .RemoveKey()
                    .AddKey(m => m.EditorID)
                    .AsObservableCache();
            },
            isThreadSafe: true);
        }

        public override string ToString()
        {
            return $"Group<{typeof(T).Name}>({this.InternalItems.Count})";
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InternalItems.Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalItems.GetEnumerator();
        }
    }

    namespace Internals
    {
        public static class GroupRecordTypeGetter<T>
        {
            public static readonly RecordType GRUP_RECORD_TYPE = (RecordType)LoquiRegistration.GetRegister(typeof(T)).ClassType.GetField(Mutagen.Bethesda.Constants.GRUP_RECORDTYPE_MEMBER).GetValue(null);
        }

        public class GroupMajorRecordCacheWrapper<T> : IReadOnlyCache<T, FormKey>
        {
            private readonly IReadOnlyDictionary<FormKey, int> _locs;
            private readonly ReadOnlyMemorySlice<byte> _data;
            private readonly BinaryWrapperFactoryPackage _package;

            public GroupMajorRecordCacheWrapper(
                IReadOnlyDictionary<FormKey, int> locs,
                ReadOnlyMemorySlice<byte> data,
                BinaryWrapperFactoryPackage package)
            {
                this._locs = locs;
                this._data = data;
                this._package = package;
            }

            public T this[FormKey key] => ConstructWrapper(this._locs[key]);

            public int Count => this._locs.Count;

            public IEnumerable<FormKey> Keys => this._locs.Keys;

            public IEnumerable<T> Values => this.Select(kv => kv.Value);

            public bool ContainsKey(FormKey key) => this._locs.ContainsKey(key);

            public IEnumerator<IKeyValue<T, FormKey>> GetEnumerator()
            {
                foreach (var kv in this._locs)
                {
                    yield return new KeyValue<T, FormKey>(kv.Key, ConstructWrapper(kv.Value));
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            private T ConstructWrapper(int pos)
            {
                return LoquiBinaryWrapperTranslation<T>.Create(
                   stream: new BinaryMemoryReadStream(this._data.Slice(pos)),
                   package: _package,
                   recordTypeConverter: null);
            }

            public static GroupMajorRecordCacheWrapper<T> Factory(
                BinaryMemoryReadStream stream, 
                ReadOnlyMemorySlice<byte> data,
                BinaryWrapperFactoryPackage package, 
                int offset)
            {
                Dictionary<FormKey, int> locationDict = new Dictionary<FormKey, int>();

                var groupMeta = package.Meta.Group(stream.Data.Span.Slice(stream.Position - package.Meta.GroupConstants.HeaderLength));
                var finalPos = stream.Position + groupMeta.ContentLength;
                // Parse MajorRecord locations
                ObjectType? lastParsed = default;
                while (stream.Position < finalPos)
                {
                    VariableHeaderMeta varMeta = package.Meta.NextRecordVariableMeta(stream.RemainingSpan);
                    if (varMeta.IsGroup)
                    {
                        if (lastParsed != ObjectType.Record)
                        {
                            throw new DataMisalignedException("Unexpected Group encountered which was not after a major record: " + GroupRecordTypeGetter<T>.GRUP_RECORD_TYPE);
                        }
                        stream.Position += checked((int)varMeta.TotalLength);
                        lastParsed = ObjectType.Group;
                    }
                    else
                    {
                        MajorRecordMeta majorMeta = package.Meta.MajorRecord(stream.RemainingSpan);
                        if (majorMeta.RecordType != GroupRecordTypeGetter<T>.GRUP_RECORD_TYPE)
                        {
                            throw new DataMisalignedException("Unexpected type encountered when parsing MajorRecord locations: " + majorMeta.RecordType);
                        }
                        var formKey = FormKey.Factory(package.MasterReferences, majorMeta.FormID.Raw);
                        locationDict.Add(formKey, stream.Position - offset);
                        stream.Position += checked((int)majorMeta.TotalLength);
                        lastParsed = ObjectType.Record;
                    }
                }

                return new GroupMajorRecordCacheWrapper<T>(
                    locationDict, 
                    data,
                    package);
            }
        }
    }
}