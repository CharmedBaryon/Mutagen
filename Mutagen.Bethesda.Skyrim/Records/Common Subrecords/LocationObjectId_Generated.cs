/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Skyrim.Internals;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Skyrim
{
    #region Class
    public partial class LocationObjectId :
        ALocationTarget,
        IEquatable<ILocationObjectIdGetter>,
        ILocationObjectId,
        ILoquiObjectSetter<LocationObjectId>
    {
        #region Ctor
        public LocationObjectId()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Link
        private IFormLink<IObjectIdGetter> _Link = new FormLink<IObjectIdGetter>();
        public IFormLink<IObjectIdGetter> Link
        {
            get => _Link;
            set => _Link = value.AsSetter();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IFormLinkGetter<IObjectIdGetter> ILocationObjectIdGetter.Link => this.Link;
        #endregion

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            LocationObjectIdMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not ILocationObjectIdGetter rhs) return false;
            return ((LocationObjectIdCommon)((ILocationObjectIdGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(ILocationObjectIdGetter? obj)
        {
            return ((LocationObjectIdCommon)((ILocationObjectIdGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((LocationObjectIdCommon)((ILocationObjectIdGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            ALocationTarget.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem Link)
            : base()
            {
                this.Link = Link;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Link;
            #endregion

            #region Equals
            public override bool Equals(object? obj)
            {
                if (!(obj is Mask<TItem> rhs)) return false;
                return Equals(rhs);
            }

            public bool Equals(Mask<TItem>? rhs)
            {
                if (rhs == null) return false;
                if (!base.Equals(rhs)) return false;
                if (!object.Equals(this.Link, rhs.Link)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Link);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.Link)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.Link)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new LocationObjectId.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.Link = eval(this.Link);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(LocationObjectId.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, LocationObjectId.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(LocationObjectId.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Link ?? true)
                    {
                        fg.AppendItem(Link, "Link");
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            ALocationTarget.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Link;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                LocationObjectId_FieldIndex enu = (LocationObjectId_FieldIndex)index;
                switch (enu)
                {
                    case LocationObjectId_FieldIndex.Link:
                        return Link;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                LocationObjectId_FieldIndex enu = (LocationObjectId_FieldIndex)index;
                switch (enu)
                {
                    case LocationObjectId_FieldIndex.Link:
                        this.Link = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                LocationObjectId_FieldIndex enu = (LocationObjectId_FieldIndex)index;
                switch (enu)
                {
                    case LocationObjectId_FieldIndex.Link:
                        this.Link = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (Link != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString()
            {
                var fg = new FileGeneration();
                ToString(fg, null);
                return fg.ToString();
            }

            public override void ToString(FileGeneration fg, string? name = null)
            {
                fg.AppendLine($"{(name ?? "ErrorMask")} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (this.Overall != null)
                    {
                        fg.AppendLine("Overall =>");
                        fg.AppendLine("[");
                        using (new DepthWrapper(fg))
                        {
                            fg.AppendLine($"{this.Overall}");
                        }
                        fg.AppendLine("]");
                    }
                    ToString_FillInternal(fg);
                }
                fg.AppendLine("]");
            }
            protected override void ToString_FillInternal(FileGeneration fg)
            {
                base.ToString_FillInternal(fg);
                fg.AppendItem(Link, "Link");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Link = this.Link.Combine(rhs.Link);
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static new ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public new class TranslationMask :
            ALocationTarget.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool Link;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
                this.Link = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((Link, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Mutagen
        public override IEnumerable<FormLinkInformation> ContainedFormLinks => LocationObjectIdCommon.Instance.GetContainedFormLinks(this);
        public override void RemapLinks(IReadOnlyDictionary<FormKey, FormKey> mapping) => LocationObjectIdSetterCommon.Instance.RemapLinks(this, mapping);
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => LocationObjectIdBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((LocationObjectIdBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public new static LocationObjectId CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new LocationObjectId();
            ((LocationObjectIdSetterCommon)((ILocationObjectIdGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out LocationObjectId item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(frame, recordTypeConverter);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((LocationObjectIdSetterCommon)((ILocationObjectIdGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new LocationObjectId GetNew()
        {
            return new LocationObjectId();
        }

    }
    #endregion

    #region Interface
    public partial interface ILocationObjectId :
        IALocationTarget,
        IFormLinkContainer,
        ILocationObjectIdGetter,
        ILoquiObjectSetter<ILocationObjectId>
    {
        new IFormLink<IObjectIdGetter> Link { get; }
    }

    public partial interface ILocationObjectIdGetter :
        IALocationTargetGetter,
        IBinaryItem,
        IFormLinkContainerGetter,
        ILoquiObject<ILocationObjectIdGetter>
    {
        static new ILoquiRegistration Registration => LocationObjectId_Registration.Instance;
        IFormLinkGetter<IObjectIdGetter> Link { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class LocationObjectIdMixIn
    {
        public static void Clear(this ILocationObjectId item)
        {
            ((LocationObjectIdSetterCommon)((ILocationObjectIdGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static LocationObjectId.Mask<bool> GetEqualsMask(
            this ILocationObjectIdGetter item,
            ILocationObjectIdGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this ILocationObjectIdGetter item,
            string? name = null,
            LocationObjectId.Mask<bool>? printMask = null)
        {
            return ((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this ILocationObjectIdGetter item,
            FileGeneration fg,
            string? name = null,
            LocationObjectId.Mask<bool>? printMask = null)
        {
            ((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this ILocationObjectIdGetter item,
            ILocationObjectIdGetter rhs,
            LocationObjectId.TranslationMask? equalsMask = null)
        {
            return ((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this ILocationObjectId lhs,
            ILocationObjectIdGetter rhs,
            out LocationObjectId.ErrorMask errorMask,
            LocationObjectId.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = LocationObjectId.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this ILocationObjectId lhs,
            ILocationObjectIdGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static LocationObjectId DeepCopy(
            this ILocationObjectIdGetter item,
            LocationObjectId.TranslationMask? copyMask = null)
        {
            return ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static LocationObjectId DeepCopy(
            this ILocationObjectIdGetter item,
            out LocationObjectId.ErrorMask errorMask,
            LocationObjectId.TranslationMask? copyMask = null)
        {
            return ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static LocationObjectId DeepCopy(
            this ILocationObjectIdGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this ILocationObjectId item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((LocationObjectIdSetterCommon)((ILocationObjectIdGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim.Internals
{
    #region Field Index
    public enum LocationObjectId_FieldIndex
    {
        Link = 0,
    }
    #endregion

    #region Registration
    public partial class LocationObjectId_Registration : ILoquiRegistration
    {
        public static readonly LocationObjectId_Registration Instance = new LocationObjectId_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 228,
            version: 0);

        public const string GUID = "54ba012b-8274-4fb8-bbba-2e9ea5e37340";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 1;

        public static readonly Type MaskType = typeof(LocationObjectId.Mask<>);

        public static readonly Type ErrorMaskType = typeof(LocationObjectId.ErrorMask);

        public static readonly Type ClassType = typeof(LocationObjectId);

        public static readonly Type GetterType = typeof(ILocationObjectIdGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(ILocationObjectId);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.LocationObjectId";

        public const string Name = "LocationObjectId";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(LocationObjectIdBinaryWriteTranslation);
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        ushort ILoquiRegistration.FieldCount => FieldCount;
        ushort ILoquiRegistration.AdditionalFieldCount => AdditionalFieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type? ILoquiRegistration.InternalSetterType => InternalSetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type? ILoquiRegistration.InternalGetterType => InternalGetterType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type? ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => throw new NotImplementedException();
        string ILoquiRegistration.GetNthName(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsNthDerivative(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsProtected(ushort index) => throw new NotImplementedException();
        Type ILoquiRegistration.GetNthType(ushort index) => throw new NotImplementedException();
        #endregion

    }
    #endregion

    #region Common
    public partial class LocationObjectIdSetterCommon : ALocationTargetSetterCommon
    {
        public new static readonly LocationObjectIdSetterCommon Instance = new LocationObjectIdSetterCommon();

        partial void ClearPartial();
        
        public void Clear(ILocationObjectId item)
        {
            ClearPartial();
            item.Link.Clear();
            base.Clear(item);
        }
        
        public override void Clear(IALocationTarget item)
        {
            Clear(item: (ILocationObjectId)item);
        }
        
        #region Mutagen
        public void RemapLinks(ILocationObjectId obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
            obj.Link.Relink(mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            ILocationObjectId item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            UtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: LocationObjectIdBinaryCreateTranslation.FillBinaryStructs);
        }
        
        public override void CopyInFromBinary(
            IALocationTarget item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (LocationObjectId)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        #endregion
        
    }
    public partial class LocationObjectIdCommon : ALocationTargetCommon
    {
        public new static readonly LocationObjectIdCommon Instance = new LocationObjectIdCommon();

        public LocationObjectId.Mask<bool> GetEqualsMask(
            ILocationObjectIdGetter item,
            ILocationObjectIdGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new LocationObjectId.Mask<bool>(false);
            ((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            ILocationObjectIdGetter item,
            ILocationObjectIdGetter rhs,
            LocationObjectId.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Link = item.Link.Equals(rhs.Link);
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            ILocationObjectIdGetter item,
            string? name = null,
            LocationObjectId.Mask<bool>? printMask = null)
        {
            var fg = new FileGeneration();
            ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
            return fg.ToString();
        }
        
        public void ToString(
            ILocationObjectIdGetter item,
            FileGeneration fg,
            string? name = null,
            LocationObjectId.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"LocationObjectId =>");
            }
            else
            {
                fg.AppendLine($"{name} (LocationObjectId) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                ToStringFields(
                    item: item,
                    fg: fg,
                    printMask: printMask);
            }
            fg.AppendLine("]");
        }
        
        protected static void ToStringFields(
            ILocationObjectIdGetter item,
            FileGeneration fg,
            LocationObjectId.Mask<bool>? printMask = null)
        {
            ALocationTargetCommon.ToStringFields(
                item: item,
                fg: fg,
                printMask: printMask);
            if (printMask?.Link ?? true)
            {
                fg.AppendItem(item.Link.FormKey, "Link");
            }
        }
        
        public static LocationObjectId_FieldIndex ConvertFieldIndex(ALocationTarget_FieldIndex index)
        {
            switch (index)
            {
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            ILocationObjectIdGetter? lhs,
            ILocationObjectIdGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if (!base.Equals((IALocationTargetGetter)lhs, (IALocationTargetGetter)rhs, crystal)) return false;
            if ((crystal?.GetShouldTranslate((int)LocationObjectId_FieldIndex.Link) ?? true))
            {
                if (!lhs.Link.Equals(rhs.Link)) return false;
            }
            return true;
        }
        
        public override bool Equals(
            IALocationTargetGetter? lhs,
            IALocationTargetGetter? rhs,
            TranslationCrystal? crystal)
        {
            return Equals(
                lhs: (ILocationObjectIdGetter?)lhs,
                rhs: rhs as ILocationObjectIdGetter,
                crystal: crystal);
        }
        
        public virtual int GetHashCode(ILocationObjectIdGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Link);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IALocationTargetGetter item)
        {
            return GetHashCode(item: (ILocationObjectIdGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return LocationObjectId.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormLinkInformation> GetContainedFormLinks(ILocationObjectIdGetter obj)
        {
            foreach (var item in base.GetContainedFormLinks(obj))
            {
                yield return item;
            }
            yield return FormLinkInformation.Factory(obj.Link);
            yield break;
        }
        
        #endregion
        
    }
    public partial class LocationObjectIdSetterTranslationCommon : ALocationTargetSetterTranslationCommon
    {
        public new static readonly LocationObjectIdSetterTranslationCommon Instance = new LocationObjectIdSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            ILocationObjectId item,
            ILocationObjectIdGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IALocationTarget)item,
                (IALocationTargetGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)LocationObjectId_FieldIndex.Link) ?? true))
            {
                item.Link.SetTo(rhs.Link.FormKey);
            }
        }
        
        
        public override void DeepCopyIn(
            IALocationTarget item,
            IALocationTargetGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (ILocationObjectId)item,
                rhs: (ILocationObjectIdGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public LocationObjectId DeepCopy(
            ILocationObjectIdGetter item,
            LocationObjectId.TranslationMask? copyMask = null)
        {
            LocationObjectId ret = (LocationObjectId)((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).GetNew();
            ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public LocationObjectId DeepCopy(
            ILocationObjectIdGetter item,
            out LocationObjectId.ErrorMask errorMask,
            LocationObjectId.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            LocationObjectId ret = (LocationObjectId)((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).GetNew();
            ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = LocationObjectId.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public LocationObjectId DeepCopy(
            ILocationObjectIdGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            LocationObjectId ret = (LocationObjectId)((LocationObjectIdCommon)((ILocationObjectIdGetter)item).CommonInstance()!).GetNew();
            ((LocationObjectIdSetterTranslationCommon)((ILocationObjectIdGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: true);
            return ret;
        }
        
    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim
{
    public partial class LocationObjectId
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => LocationObjectId_Registration.Instance;
        public new static LocationObjectId_Registration Registration => LocationObjectId_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => LocationObjectIdCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return LocationObjectIdSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => LocationObjectIdSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class LocationObjectIdBinaryWriteTranslation :
        ALocationTargetBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static LocationObjectIdBinaryWriteTranslation Instance = new LocationObjectIdBinaryWriteTranslation();

        public static void WriteEmbedded(
            ILocationObjectIdGetter item,
            MutagenWriter writer)
        {
            Mutagen.Bethesda.Binary.FormLinkBinaryTranslation.Instance.Write(
                writer: writer,
                item: item.Link);
        }

        public void Write(
            MutagenWriter writer,
            ILocationObjectIdGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (ILocationObjectIdGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            IALocationTargetGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (ILocationObjectIdGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class LocationObjectIdBinaryCreateTranslation : ALocationTargetBinaryCreateTranslation
    {
        public new readonly static LocationObjectIdBinaryCreateTranslation Instance = new LocationObjectIdBinaryCreateTranslation();

        public static void FillBinaryStructs(
            ILocationObjectId item,
            MutagenFrame frame)
        {
            item.Link.SetTo(
                Mutagen.Bethesda.Binary.FormLinkBinaryTranslation.Instance.Parse(
                    frame: frame,
                    defaultVal: FormKey.Null));
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class LocationObjectIdBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class LocationObjectIdBinaryOverlay :
        ALocationTargetBinaryOverlay,
        ILocationObjectIdGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => LocationObjectId_Registration.Instance;
        public new static LocationObjectId_Registration Registration => LocationObjectId_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => LocationObjectIdCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => LocationObjectIdSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        public override IEnumerable<FormLinkInformation> ContainedFormLinks => LocationObjectIdCommon.Instance.GetContainedFormLinks(this);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => LocationObjectIdBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((LocationObjectIdBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public IFormLinkGetter<IObjectIdGetter> Link => new FormLink<IObjectIdGetter>(FormKey.Factory(_package.MetaData.MasterReferences!, BinaryPrimitives.ReadUInt32LittleEndian(_data.Span.Slice(0x0, 0x4))));
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected LocationObjectIdBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static LocationObjectIdBinaryOverlay LocationObjectIdFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new LocationObjectIdBinaryOverlay(
                bytes: stream.RemainingMemory.Slice(0, 0x4),
                package: package);
            int offset = stream.Position;
            stream.Position += 0x4;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static LocationObjectIdBinaryOverlay LocationObjectIdFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return LocationObjectIdFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            LocationObjectIdMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not ILocationObjectIdGetter rhs) return false;
            return ((LocationObjectIdCommon)((ILocationObjectIdGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(ILocationObjectIdGetter? obj)
        {
            return ((LocationObjectIdCommon)((ILocationObjectIdGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((LocationObjectIdCommon)((ILocationObjectIdGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

