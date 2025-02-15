using Loqui;
using Mutagen.Bethesda.Core;
using Noggog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;

namespace Mutagen.Bethesda
{
    /// <summary>
    /// A Link Cache using a single mod as its link target. <br/>
    /// <br/>
    /// Internal caching will only occur for the types required to serve the requested link. <br/>
    /// <br/>
    /// All functionality is multithread safe. <br/>
    /// <br/>
    /// Modification of the target Mod is not safe.  Internal caches can become incorrect if 
    /// modifications occur on content already cached.
    /// </summary>
    public class ImmutableModLinkCache : ILinkCache
    {
        internal readonly IModGetter _sourceMod;
        public GameCategory Category { get; }

        internal readonly bool _simple;
        private readonly ImmutableModLinkCacheCategory<FormKey> _formKeyCache;
        private readonly ImmutableModLinkCacheCategory<string> _editorIdCache;

        /// <inheritdoc />
        public IReadOnlyList<IModGetter> ListedOrder { get; }

        /// <inheritdoc />
        public IReadOnlyList<IModGetter> PriorityOrder => ListedOrder;

        public ImmutableModLinkCache(IModGetter sourceMod, LinkCachePreferences? prefs = null)
        {
            _sourceMod = sourceMod;
            Category = sourceMod.GameRelease.ToCategory();
            _simple = prefs is LinkCachePreferenceOnlyIdentifiers;
            _formKeyCache = new ImmutableModLinkCacheCategory<FormKey>(
                this, 
                x => TryGet<FormKey>.Succeed(x.FormKey),
                x => x.IsNull);
            _editorIdCache = new ImmutableModLinkCacheCategory<string>(
                this,
                m =>
                {
                    var edid = m.EditorID;
                    return TryGet<string>.Create(successful: !string.IsNullOrWhiteSpace(edid), edid!);
                },
                e => e.IsNullOrWhitespace());
            this.ListedOrder = new List<IModGetter>()
            {
                sourceMod
            };
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public bool TryResolve(FormKey formKey, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            if (formKey.IsNull)
            {
                majorRec = default;
                return false;
            }
            if (_formKeyCache._untypedMajorRecords.Value.TryGetValue(formKey, out var item))
            {
                majorRec = item.Record;
                return true;
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public bool TryResolve(string editorId, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            if (string.IsNullOrWhiteSpace(editorId))
            {
                majorRec = default;
                return false;
            }
            if (_editorIdCache._untypedMajorRecords.Value.TryGetValue(editorId, out var item))
            {
                majorRec = item.Record;
                return true;
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolve<TMajor>(FormKey formKey, [MaybeNullWhen(false)] out TMajor majorRec)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (_formKeyCache.TryResolve(formKey, typeof(TMajor), out var item))
            {
                majorRec = item.Record as TMajor;
                return majorRec != null;
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolve<TMajor>(string editorId, [MaybeNullWhen(false)] out TMajor majorRec)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (_editorIdCache.TryResolve(editorId, typeof(TMajor), out var item))
            {
                majorRec = item.Record as TMajor;
                return majorRec != null;
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolve(FormKey formKey, Type type, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            if (_formKeyCache.TryResolve(formKey, type, out var item))
            {
                majorRec = item.Record;
                return true;
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolve(string editorId, Type type, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            if (_editorIdCache.TryResolve(editorId, type, out var item))
            {
                majorRec = item.Record;
                return true;
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IMajorRecordCommonGetter Resolve(FormKey formKey)
        {
            if (TryResolve<IMajorRecordCommonGetter>(formKey, out var majorRec)) return majorRec;
            throw new MissingRecordException(formKey, typeof(IMajorRecordCommonGetter));
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IMajorRecordCommonGetter Resolve(string editorId)
        {
            if (TryResolve<IMajorRecordCommonGetter>(editorId, out var majorRec)) return majorRec;
            throw new MissingRecordException(editorId, typeof(IMajorRecordCommonGetter));
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(FormKey formKey, Type type)
        {
            if (TryResolve(formKey, type, out var commonRec)) return commonRec;
            throw new MissingRecordException(formKey, type);
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(string editorId, Type type)
        {
            if (TryResolve(editorId, type, out var commonRec)) return commonRec;
            throw new MissingRecordException(editorId, type);
        }

        /// <inheritdoc />
        public TMajor Resolve<TMajor>(FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (TryResolve<TMajor>(formKey, out var commonRec)) return commonRec;
            throw new MissingRecordException(formKey, typeof(TMajor));
        }

        /// <inheritdoc />
        public TMajor Resolve<TMajor>(string editorId)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (TryResolve<TMajor>(editorId, out var commonRec)) return commonRec;
            throw new MissingRecordException(editorId, typeof(TMajor));
        }

        /// <inheritdoc />
        public IEnumerable<TMajor> ResolveAll<TMajor>(FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (TryResolve<TMajor>(formKey, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        public IEnumerable<TMajor> ResolveAll<TMajor>(string editorId)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (TryResolve<TMajor>(editorId, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        public IEnumerable<IMajorRecordCommonGetter> ResolveAll(FormKey formKey, Type type)
        {
            if (TryResolve(formKey, type, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        public IEnumerable<IMajorRecordCommonGetter> ResolveAll(string editorId, Type type)
        {
            if (TryResolve(editorId, type, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IEnumerable<IMajorRecordCommonGetter> ResolveAll(FormKey formKey)
        {
            if (TryResolve(formKey, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IEnumerable<IMajorRecordCommonGetter> ResolveAll(string editorId)
        {
            if (TryResolve(editorId, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        public bool TryResolve(FormKey formKey, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec, params Type[] types)
        {
            return TryResolve(formKey, (IEnumerable<Type>)types, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolve(string editorId, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec, params Type[] types)
        {
            return TryResolve(editorId, (IEnumerable<Type>)types, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolve(FormKey formKey, IEnumerable<Type> types, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            foreach (var type in types)
            {
                if (TryResolve(formKey, type, out majorRec))
                {
                    return true;
                }
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolve(string editorId, IEnumerable<Type> types, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            foreach (var type in types)
            {
                if (TryResolve(editorId, type, out majorRec))
                {
                    return true;
                }
            }
            majorRec = default;
            return false;
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(FormKey formKey, params Type[] types)
        {
            return Resolve(formKey, (IEnumerable<Type>)types);
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(string editorId, params Type[] types)
        {
            return Resolve(editorId, (IEnumerable<Type>)types);
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(FormKey formKey, IEnumerable<Type> types)
        {
            if (TryResolve(formKey, types, out var commonRec)) return commonRec;
            throw new MissingRecordException(formKey, types.ToArray());
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(string editorId, IEnumerable<Type> types)
        {
            if (TryResolve(editorId, types, out var commonRec)) return commonRec;
            throw new MissingRecordException(editorId, types.ToArray());
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(FormKey formKey, [MaybeNullWhen(false)] out string? editorId)
        {
            if (formKey.IsNull)
            {
                editorId = default;
                return false;
            }
            if (_formKeyCache._untypedMajorRecords.Value.TryGetValue(formKey, out var item))
            {
                editorId = item.EditorID;
                return true;
            }
            editorId = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(string editorId, [MaybeNullWhen(false)] out FormKey formKey)
        {
            if (string.IsNullOrWhiteSpace(editorId))
            {
                formKey = default;
                return false;
            }
            if (_editorIdCache._untypedMajorRecords.Value.TryGetValue(editorId, out var item))
            {
                formKey = item.FormKey;
                return true;
            }
            formKey = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(FormKey formKey, Type type, [MaybeNullWhen(false)] out string? editorId)
        {
            if (_formKeyCache.TryResolve(formKey, type, out var item))
            {
                editorId = item.EditorID;
                return true;
            }
            editorId = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(string editorId, Type type, [MaybeNullWhen(false)] out FormKey formKey)
        {
            if (_editorIdCache.TryResolve(editorId, type, out var item))
            {
                formKey = item.FormKey;
                return true;
            }
            formKey = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier<TMajor>(FormKey formKey, out string? editorId)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (_formKeyCache.TryResolve(formKey, typeof(TMajor), out var item))
            {
                editorId = item.EditorID;
                return true;
            }
            editorId = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier<TMajor>(string editorId, out FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (_editorIdCache.TryResolve(editorId, typeof(TMajor), out var item))
            {
                formKey = item.FormKey;
                return true;
            }
            formKey = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(FormKey formKey, [MaybeNullWhen(false)] out string? editorId, params Type[] types)
        {
            return TryResolveIdentifier(formKey, (IEnumerable<Type>)types, out editorId);
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(string editorId, [MaybeNullWhen(false)] out FormKey formKey, params Type[] types)
        {
            return TryResolveIdentifier(editorId, (IEnumerable<Type>)types, out formKey);
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(FormKey formKey, IEnumerable<Type> types, [MaybeNullWhen(false)] out string? editorId)
        {
            foreach (var type in types)
            {
                if (TryResolveIdentifier(formKey, type, out editorId))
                {
                    return true;
                }
            }
            editorId = default;
            return false;
        }

        /// <inheritdoc />
        public bool TryResolveIdentifier(string editorId, IEnumerable<Type> types, [MaybeNullWhen(false)] out FormKey formKey)
        {
            foreach (var type in types)
            {
                if (TryResolveIdentifier(editorId, type, out formKey))
                {
                    return true;
                }
            }
            formKey = default;
            return false;
        }

        /// <inheritdoc />
        public IEnumerable<IMajorRecordIdentifier> AllIdentifiers(Type type, CancellationToken? cancel = null)
        {
            return _formKeyCache.AllIdentifiers(type, cancel);
        }

        /// <inheritdoc />
        public IEnumerable<IMajorRecordIdentifier> AllIdentifiers<TMajor>(CancellationToken? cancel = null)
            where TMajor : class, IMajorRecordCommonGetter
        {
            return _formKeyCache.AllIdentifiers(typeof(TMajor), cancel);
        }

        /// <inheritdoc />
        public IEnumerable<IMajorRecordIdentifier> AllIdentifiers(params Type[] types)
        {
            return AllIdentifiers((IEnumerable<Type>)types, CancellationToken.None);
        }

        /// <inheritdoc />
        public IEnumerable<IMajorRecordIdentifier> AllIdentifiers(IEnumerable<Type> types, CancellationToken? cancel = null)
        {
            return types.SelectMany(type => AllIdentifiers(type, cancel))
                .Distinct(x => x.FormKey);
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public void Warmup(Type type)
        {
            _formKeyCache.Warmup(type);
        }

        /// <inheritdoc />
        public void Warmup<TMajor>()
        {
            _formKeyCache.Warmup(typeof(TMajor));
        }

        /// <inheritdoc />
        public void Warmup(params Type[] types)
        {
            Warmup((IEnumerable<Type>)types);
        }

        /// <inheritdoc />
        public void Warmup(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                _formKeyCache.Warmup(type);
            }
        }
    }

    internal class ImmutableModLinkCacheCategory<K>
        where K : notnull
    {
        private readonly ImmutableModLinkCache _parent;
        private readonly Func<LinkCacheItem, TryGet<K>> _keyGetter;
        private readonly Func<K, bool> _shortCircuit;
        internal readonly Lazy<IReadOnlyCache<LinkCacheItem, K>> _untypedMajorRecords;
        private readonly Dictionary<Type, IReadOnlyCache<LinkCacheItem, K>> _majorRecords = new Dictionary<Type, IReadOnlyCache<LinkCacheItem, K>>();

        public ImmutableModLinkCacheCategory(
            ImmutableModLinkCache parent,
            Func<LinkCacheItem, TryGet<K>> keyGetter,
            Func<K, bool> shortCircuit)
        {
            _parent = parent;
            _keyGetter = keyGetter;
            _shortCircuit = shortCircuit;
            _untypedMajorRecords = new Lazy<IReadOnlyCache<LinkCacheItem, K>>(
                isThreadSafe: true,
                valueFactory: () => ConstructUntypedCache());
        }

        protected IReadOnlyCache<LinkCacheItem, K> ConstructUntypedCache()
        {
            var majorRecords = new Cache<LinkCacheItem, K>(x => _keyGetter(x).Value);
            foreach (var majorRec in _parent._sourceMod.EnumerateMajorRecords()
                // ToDo
                // Capture and expose errors optionally via TryResolve /w out param
                .Catch((Exception ex) => { }))
            {
                var item = LinkCacheItem.Factory(majorRec, _parent._simple);
                var key = _keyGetter(item);
                if (key.Failed) continue;
                majorRecords.Set(item);
            }
            return majorRecords;
        }

        private IReadOnlyCache<LinkCacheItem, K> ConstructTypedCache(
            Type type,
            IModGetter sourceMod)
        {
            var cache = new Cache<LinkCacheItem, K>(x => _keyGetter(x).Value);
            foreach (var majorRec in sourceMod.EnumerateMajorRecords(type)
                // ToDo
                // Capture and expose errors optionally via TryResolve /w out param
                .Catch((Exception ex) => { }))
            {
                var item = LinkCacheItem.Factory(majorRec, _parent._simple);
                var key = _keyGetter(item);
                if (key.Failed) continue;
                cache.Set(item);
            }
            return cache;
        }

        public IReadOnlyCache<LinkCacheItem, K> GetCache(
            Type type,
            GameCategory category,
            IModGetter sourceMod)
        {
            lock (_majorRecords)
            {
                if (!_majorRecords.TryGetValue(type, out var cache))
                {
                    if (type.Equals(typeof(IMajorRecordCommon))
                        || type.Equals(typeof(IMajorRecordCommonGetter)))
                    {
                        cache = ConstructTypedCache(type, sourceMod);
                        _majorRecords[typeof(IMajorRecordCommon)] = cache;
                        _majorRecords[typeof(IMajorRecordCommonGetter)] = cache;
                    }
                    else if (LoquiRegistration.TryGetRegister(type, out var registration))
                    {
                        cache = ConstructTypedCache(type, sourceMod);
                        _majorRecords[registration.ClassType] = cache;
                        _majorRecords[registration.GetterType] = cache;
                        _majorRecords[registration.SetterType] = cache;
                        if (registration.InternalGetterType != null)
                        {
                            _majorRecords[registration.InternalGetterType] = cache;
                        }
                        if (registration.InternalSetterType != null)
                        {
                            _majorRecords[registration.InternalSetterType] = cache;
                        }
                    }
                    else
                    {
                        var interfaceMappings = LinkInterfaceMapping.InterfaceToObjectTypes(category);
                        if (!interfaceMappings.TryGetValue(type, out var objs))
                        {
                            throw new ArgumentException($"A lookup was queried for an unregistered type: {type.Name}");
                        }
                        var majorRecords = new Cache<LinkCacheItem, K>(x => _keyGetter(x).Value);
                        foreach (var objType in objs)
                        {
                            majorRecords.Set(
                                GetCache(
                                    type: LoquiRegistration.GetRegister(objType).GetterType,
                                    category: category,
                                    sourceMod: sourceMod).Items);
                        }
                        _majorRecords[type] = majorRecords;
                        cache = majorRecords;
                    }
                }
                return cache;
            }
        }

        public bool TryResolve(K key, Type type, [MaybeNullWhen(false)] out LinkCacheItem majorRec)
        {
            if (_shortCircuit(key))
            {
                majorRec = default;
                return false;
            }
            var cache = GetCache(type, _parent.Category, _parent._sourceMod);
            if (!cache.TryGetValue(key, out majorRec))
            {
                majorRec = default;
                return false;
            }
            return true;
        }

        public IEnumerable<LinkCacheItem> AllIdentifiers(Type type, CancellationToken? cancel)
        {
            return GetCache(type, _parent.Category, _parent._sourceMod).Items;
        }

        public void Warmup(Type type)
        {
            GetCache(type, _parent.Category, _parent._sourceMod);
        }
    }

    /// <summary>
    /// A Link Cache using a single mod as its link target. <br/>
    /// <br/>
    /// Internal caching will only occur for the types required to serve the requested link. <br/>
    /// <br/>
    /// All functionality is multithread safe. <br/>
    /// <br/>
    /// Modification of the target Mod is not safe.  Internal caches can become incorrect if 
    /// modifications occur on content already cached.
    /// </summary>
    public class ImmutableModLinkCache<TMod, TModGetter> : ImmutableModLinkCache, ILinkCache<TMod, TModGetter>
        where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
        where TModGetter : class, IContextGetterMod<TMod, TModGetter>
    {
        internal new readonly TModGetter _sourceMod;

        private readonly ImmutableModLinkCacheContextCategory<TMod, TModGetter, FormKey> _formKeyContexts;
        private readonly ImmutableModLinkCacheContextCategory<TMod, TModGetter, string> _editorIdContexts;

        /// <summary>
        /// Constructs a link cache around a target mod
        /// </summary>
        /// <param name="sourceMod">Mod to resolve against when linking</param>
        public ImmutableModLinkCache(TModGetter sourceMod, LinkCachePreferences prefs)
            : base(sourceMod, prefs)
        {
            this._sourceMod = sourceMod;
            _formKeyContexts = new ImmutableModLinkCacheContextCategory<TMod, TModGetter, FormKey>(
                parent: this,
                keyGetter: m => TryGet<FormKey>.Succeed(m.FormKey),
                shortCircuit: f => f.IsNull);
            _editorIdContexts = new ImmutableModLinkCacheContextCategory<TMod, TModGetter, string>(
                parent: this,
                keyGetter: m =>
                {
                    var edid = m.EditorID;
                    return TryGet<string>.Create(successful: !string.IsNullOrWhiteSpace(edid), edid!);
                },
                shortCircuit: e => e.IsNullOrWhitespace());
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public bool TryResolveContext(FormKey formKey, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> majorRec)
        {
            if (formKey.IsNull)
            {
                majorRec = default;
                return false;
            }
            return _formKeyContexts._untypedContexts.Value.TryGetValue(formKey, out majorRec);
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public bool TryResolveContext(string editorId, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> majorRec)
        {
            if (editorId.IsNullOrWhitespace())
            {
                majorRec = default;
                return false;
            }
            return _editorIdContexts._untypedContexts.Value.TryGetValue(editorId, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolveContext<TMajor, TMajorGetter>(FormKey formKey, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, TMajor, TMajorGetter> majorRec)
            where TMajor : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            return _formKeyContexts.TryResolveContext(formKey, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolveContext<TMajor, TMajorGetter>(string editorId, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, TMajor, TMajorGetter> majorRec)
            where TMajor : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            return _editorIdContexts.TryResolveContext(editorId, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolveContext(FormKey formKey, Type type, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> majorRec)
        {
            return _formKeyContexts.TryResolveContext(formKey, type, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolveContext(string editorId, Type type, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> majorRec)
        {
            return _editorIdContexts.TryResolveContext(editorId, type, out majorRec);
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> ResolveContext(FormKey formKey)
        {
            if (TryResolveContext<IMajorRecordCommon, IMajorRecordCommonGetter>(formKey, out var majorRec)) return majorRec;
            throw new MissingRecordException(formKey, typeof(IMajorRecordCommonGetter));
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> ResolveContext(string editorId)
        {
            if (TryResolveContext<IMajorRecordCommon, IMajorRecordCommonGetter>(editorId, out var majorRec)) return majorRec;
            throw new MissingRecordException(editorId, typeof(IMajorRecordCommonGetter));
        }

        /// <inheritdoc />
        public IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> ResolveContext(FormKey formKey, Type type)
        {
            if (TryResolveContext(formKey, type, out var commonRec)) return commonRec;
            throw new MissingRecordException(formKey, type);
        }

        /// <inheritdoc />
        public IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> ResolveContext(string editorId, Type type)
        {
            if (TryResolveContext(editorId, type, out var commonRec)) return commonRec;
            throw new MissingRecordException(editorId, type);
        }

        /// <inheritdoc />
        public IModContext<TMod, TModGetter, TMajor, TMajorGetter> ResolveContext<TMajor, TMajorGetter>(FormKey formKey)
            where TMajor : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (TryResolveContext<TMajor, TMajorGetter>(formKey, out var commonRec)) return commonRec;
            throw new MissingRecordException(formKey, typeof(TMajorGetter));
        }

        /// <inheritdoc />
        public IModContext<TMod, TModGetter, TMajor, TMajorGetter> ResolveContext<TMajor, TMajorGetter>(string editorId)
            where TMajor : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (TryResolveContext<TMajor, TMajorGetter>(editorId, out var commonRec)) return commonRec;
            throw new MissingRecordException(editorId, typeof(TMajorGetter));
        }

        /// <inheritdoc />
        public IEnumerable<IModContext<TMod, TModGetter, TMajor, TMajorGetter>> ResolveAllContexts<TMajor, TMajorGetter>(FormKey formKey)
            where TMajor : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (TryResolveContext<TMajor, TMajorGetter>(formKey, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        public IEnumerable<IModContext<TMod, TModGetter, TMajor, TMajorGetter>> ResolveAllContexts<TMajor, TMajorGetter>(string editorId)
            where TMajor : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (TryResolveContext<TMajor, TMajorGetter>(editorId, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        public IEnumerable<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>> ResolveAllContexts(FormKey formKey, Type type)
        {
            if (TryResolveContext(formKey, type, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        public IEnumerable<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>> ResolveAllContexts(string editorId, Type type)
        {
            if (TryResolveContext(editorId, type, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IEnumerable<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>> ResolveAllContexts(FormKey formKey)
        {
            if (TryResolveContext(formKey, out var rec))
            {
                yield return rec;
            }
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IEnumerable<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>> ResolveAllContexts(string editorId)
        {
            if (TryResolveContext(editorId, out var rec))
            {
                yield return rec;
            }
        }
    }

    internal class ImmutableModLinkCacheContextCategory<TMod, TModGetter, K>
        where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
        where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        where K : notnull
    {
        private readonly ImmutableModLinkCache<TMod, TModGetter> _parent;
        private readonly Func<IMajorRecordCommonGetter, TryGet<K>> _keyGetter;
        private readonly Func<K, bool> _shortCircuit;
        internal readonly Lazy<IReadOnlyCache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K>> _untypedContexts;
        private readonly Dictionary<Type, IReadOnlyCache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K>> _contexts = new();

        public ImmutableModLinkCacheContextCategory(
            ImmutableModLinkCache<TMod, TModGetter> parent,
            Func<IMajorRecordCommonGetter, TryGet<K>> keyGetter,
            Func<K, bool> shortCircuit)
        {
            _parent = parent;
            _keyGetter = keyGetter;
            _shortCircuit = shortCircuit;
            _untypedContexts = new Lazy<IReadOnlyCache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K>>(
                isThreadSafe: true,
                valueFactory: () => ConstructUntypedContextCache());
        }

        private IReadOnlyCache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K> ConstructUntypedContextCache()
        {
            var majorRecords = new Cache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K>(x => _keyGetter(x.Record).Value);
            foreach (var majorRec in this._parent._sourceMod.EnumerateMajorRecordContexts<IMajorRecordCommon, IMajorRecordCommonGetter>(_parent))
            {
                var key = _keyGetter(majorRec.Record);
                if (key.Failed) continue;
                majorRecords.Set(majorRec);
            }
            return majorRecords;
        }

        public bool TryResolveContext<TMajor, TMajorGetter>(K key, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, TMajor, TMajorGetter> majorRec)
            where TMajor : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (_shortCircuit(key))
            {
                majorRec = default;
                return false;
            }
            var cache = GetContextCache(typeof(TMajorGetter));
            if (!cache.TryGetValue(key, out var majorRecObj)
                || !(majorRecObj.Record is TMajorGetter))
            {
                majorRec = default;
                return false;
            }
            majorRec = majorRecObj.AsType<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter, TMajor, TMajorGetter>();
            return true;
        }

        public bool TryResolveContext(K key, Type type, [MaybeNullWhen(false)] out IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter> majorRec)
        {
            if (_shortCircuit(key))
            {
                majorRec = default;
                return false;
            }
            var cache = GetContextCache(type);
            if (!cache.TryGetValue(key, out majorRec))
            {
                majorRec = default;
                return false;
            }
            return true;
        }

        private IReadOnlyCache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K> GetContextCache(Type type)
        {
            lock (_contexts)
            {
                if (!_contexts.TryGetValue(type, out var cache))
                {
                    if (type.Equals(typeof(IMajorRecordCommon))
                        || type.Equals(typeof(IMajorRecordCommonGetter)))
                    {
                        cache = ConstructContextCache(type);
                        _contexts[typeof(IMajorRecordCommon)] = cache;
                        _contexts[typeof(IMajorRecordCommonGetter)] = cache;
                    }
                    else if (LoquiRegistration.TryGetRegister(type, out var registration))
                    {
                        cache = ConstructContextCache(type);
                        _contexts[registration.ClassType] = cache;
                        _contexts[registration.GetterType] = cache;
                        _contexts[registration.SetterType] = cache;
                        if (registration.InternalGetterType != null)
                        {
                            _contexts[registration.InternalGetterType] = cache;
                        }
                        if (registration.InternalSetterType != null)
                        {
                            _contexts[registration.InternalSetterType] = cache;
                        }
                    }
                    else
                    {
                        var interfaceMappings = LinkInterfaceMapping.InterfaceToObjectTypes(_parent._sourceMod.GameRelease.ToCategory());
                        if (!interfaceMappings.TryGetValue(type, out var objs))
                        {
                            throw new ArgumentException($"A lookup was queried for an unregistered type: {type.Name}");
                        }
                        var majorRecords = new Cache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K>(x => _keyGetter(x.Record).Value);
                        foreach (var objType in objs)
                        {
                            majorRecords.Set(
                                GetContextCache(
                                    LoquiRegistration.GetRegister(objType).GetterType).Items);
                        }
                        _contexts[type] = majorRecords;
                        cache = majorRecords;
                    }
                }
                return cache;
            }
        }

        private IReadOnlyCache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K> ConstructContextCache(Type type)
        {
            var cache = new Cache<IModContext<TMod, TModGetter, IMajorRecordCommon, IMajorRecordCommonGetter>, K>(x => _keyGetter(x.Record).Value);
            // ToDo
            // Upgrade to call EnumerateGroups(), which will perform much better
            foreach (var majorRec in _parent._sourceMod.EnumerateMajorRecordContexts(_parent, type))
            {
                var key = _keyGetter(majorRec.Record);
                if (key.Failed) continue;
                cache.Set(majorRec);
            }
            return cache;
        }
    }
}
