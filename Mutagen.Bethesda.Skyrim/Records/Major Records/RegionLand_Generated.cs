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
    public partial class RegionLand :
        RegionData,
        IEquatable<IRegionLandGetter>,
        ILoquiObjectSetter<RegionLand>,
        IRegionLand
    {
        #region Ctor
        public RegionLand()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            RegionLandMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IRegionLandGetter rhs) return false;
            return ((RegionLandCommon)((IRegionLandGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IRegionLandGetter? obj)
        {
            return ((RegionLandCommon)((IRegionLandGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((RegionLandCommon)((IRegionLandGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            RegionData.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
            : base(initialValue)
            {
            }

            public Mask(
                TItem Header,
                TItem Icons)
            : base(
                Header: Header,
                Icons: Icons)
            {
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

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
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new RegionLand.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(RegionLand.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, RegionLand.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(RegionLand.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            RegionData.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                RegionLand_FieldIndex enu = (RegionLand_FieldIndex)index;
                switch (enu)
                {
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                RegionLand_FieldIndex enu = (RegionLand_FieldIndex)index;
                switch (enu)
                {
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                RegionLand_FieldIndex enu = (RegionLand_FieldIndex)index;
                switch (enu)
                {
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
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
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
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
            RegionData.TranslationMask,
            ITranslationMask
        {
            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
            }

            #endregion

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => RegionLandBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((RegionLandBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public new static RegionLand CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new RegionLand();
            ((RegionLandSetterCommon)((IRegionLandGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out RegionLand item,
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
            ((RegionLandSetterCommon)((IRegionLandGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new RegionLand GetNew()
        {
            return new RegionLand();
        }

    }
    #endregion

    #region Interface
    public partial interface IRegionLand :
        IHasIcons,
        ILoquiObjectSetter<IRegionLand>,
        IRegionData,
        IRegionLandGetter
    {
    }

    public partial interface IRegionLandGetter :
        IRegionDataGetter,
        IBinaryItem,
        IHasIconsGetter,
        ILoquiObject<IRegionLandGetter>
    {
        static new ILoquiRegistration Registration => RegionLand_Registration.Instance;

    }

    #endregion

    #region Common MixIn
    public static partial class RegionLandMixIn
    {
        public static void Clear(this IRegionLand item)
        {
            ((RegionLandSetterCommon)((IRegionLandGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static RegionLand.Mask<bool> GetEqualsMask(
            this IRegionLandGetter item,
            IRegionLandGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IRegionLandGetter item,
            string? name = null,
            RegionLand.Mask<bool>? printMask = null)
        {
            return ((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IRegionLandGetter item,
            FileGeneration fg,
            string? name = null,
            RegionLand.Mask<bool>? printMask = null)
        {
            ((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IRegionLandGetter item,
            IRegionLandGetter rhs,
            RegionLand.TranslationMask? equalsMask = null)
        {
            return ((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IRegionLand lhs,
            IRegionLandGetter rhs,
            out RegionLand.ErrorMask errorMask,
            RegionLand.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((RegionLandSetterTranslationCommon)((IRegionLandGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = RegionLand.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IRegionLand lhs,
            IRegionLandGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((RegionLandSetterTranslationCommon)((IRegionLandGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static RegionLand DeepCopy(
            this IRegionLandGetter item,
            RegionLand.TranslationMask? copyMask = null)
        {
            return ((RegionLandSetterTranslationCommon)((IRegionLandGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static RegionLand DeepCopy(
            this IRegionLandGetter item,
            out RegionLand.ErrorMask errorMask,
            RegionLand.TranslationMask? copyMask = null)
        {
            return ((RegionLandSetterTranslationCommon)((IRegionLandGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static RegionLand DeepCopy(
            this IRegionLandGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((RegionLandSetterTranslationCommon)((IRegionLandGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IRegionLand item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((RegionLandSetterCommon)((IRegionLandGetter)item).CommonSetterInstance()!).CopyInFromBinary(
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
    public enum RegionLand_FieldIndex
    {
        Header = 0,
        Icons = 1,
    }
    #endregion

    #region Registration
    public partial class RegionLand_Registration : ILoquiRegistration
    {
        public static readonly RegionLand_Registration Instance = new RegionLand_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 271,
            version: 0);

        public const string GUID = "4c0cb6ae-ed79-4884-b04b-7f0fd61f3fff";

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(RegionLand.Mask<>);

        public static readonly Type ErrorMaskType = typeof(RegionLand.ErrorMask);

        public static readonly Type ClassType = typeof(RegionLand);

        public static readonly Type GetterType = typeof(IRegionLandGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IRegionLand);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.RegionLand";

        public const string Name = "RegionLand";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static ICollectionGetter<RecordType> TriggeringRecordTypes => _TriggeringRecordTypes.Value;
        private static readonly Lazy<ICollectionGetter<RecordType>> _TriggeringRecordTypes = new Lazy<ICollectionGetter<RecordType>>(() =>
        {
            return new CollectionGetterWrapper<RecordType>(
                new HashSet<RecordType>(
                    new RecordType[]
                    {
                        RecordTypes.RDAT,
                        RecordTypes.ICON
                    })
            );
        });
        public static readonly Type BinaryWriteTranslation = typeof(RegionLandBinaryWriteTranslation);
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
    public partial class RegionLandSetterCommon : RegionDataSetterCommon
    {
        public new static readonly RegionLandSetterCommon Instance = new RegionLandSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IRegionLand item)
        {
            ClearPartial();
            base.Clear(item);
        }
        
        public override void Clear(IRegionData item)
        {
            Clear(item: (IRegionLand)item);
        }
        
        #region Mutagen
        public void RemapLinks(IRegionLand obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IRegionLand item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            UtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: RegionLandBinaryCreateTranslation.FillBinaryStructs,
                fillTyped: RegionLandBinaryCreateTranslation.FillBinaryRecordTypes);
        }
        
        public override void CopyInFromBinary(
            IRegionData item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (RegionLand)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        #endregion
        
    }
    public partial class RegionLandCommon : RegionDataCommon
    {
        public new static readonly RegionLandCommon Instance = new RegionLandCommon();

        public RegionLand.Mask<bool> GetEqualsMask(
            IRegionLandGetter item,
            IRegionLandGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new RegionLand.Mask<bool>(false);
            ((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IRegionLandGetter item,
            IRegionLandGetter rhs,
            RegionLand.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            IRegionLandGetter item,
            string? name = null,
            RegionLand.Mask<bool>? printMask = null)
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
            IRegionLandGetter item,
            FileGeneration fg,
            string? name = null,
            RegionLand.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"RegionLand =>");
            }
            else
            {
                fg.AppendLine($"{name} (RegionLand) =>");
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
            IRegionLandGetter item,
            FileGeneration fg,
            RegionLand.Mask<bool>? printMask = null)
        {
            RegionDataCommon.ToStringFields(
                item: item,
                fg: fg,
                printMask: printMask);
        }
        
        public static RegionLand_FieldIndex ConvertFieldIndex(RegionData_FieldIndex index)
        {
            switch (index)
            {
                case RegionData_FieldIndex.Header:
                    return (RegionLand_FieldIndex)((int)index);
                case RegionData_FieldIndex.Icons:
                    return (RegionLand_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IRegionLandGetter? lhs,
            IRegionLandGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if (!base.Equals((IRegionDataGetter)lhs, (IRegionDataGetter)rhs, crystal)) return false;
            return true;
        }
        
        public override bool Equals(
            IRegionDataGetter? lhs,
            IRegionDataGetter? rhs,
            TranslationCrystal? crystal)
        {
            return Equals(
                lhs: (IRegionLandGetter?)lhs,
                rhs: rhs as IRegionLandGetter,
                crystal: crystal);
        }
        
        public virtual int GetHashCode(IRegionLandGetter item)
        {
            var hash = new HashCode();
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IRegionDataGetter item)
        {
            return GetHashCode(item: (IRegionLandGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return RegionLand.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormLinkInformation> GetContainedFormLinks(IRegionLandGetter obj)
        {
            foreach (var item in base.GetContainedFormLinks(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        #endregion
        
    }
    public partial class RegionLandSetterTranslationCommon : RegionDataSetterTranslationCommon
    {
        public new static readonly RegionLandSetterTranslationCommon Instance = new RegionLandSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IRegionLand item,
            IRegionLandGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IRegionData)item,
                (IRegionDataGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
        }
        
        
        public override void DeepCopyIn(
            IRegionData item,
            IRegionDataGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IRegionLand)item,
                rhs: (IRegionLandGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public RegionLand DeepCopy(
            IRegionLandGetter item,
            RegionLand.TranslationMask? copyMask = null)
        {
            RegionLand ret = (RegionLand)((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).GetNew();
            ((RegionLandSetterTranslationCommon)((IRegionLandGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public RegionLand DeepCopy(
            IRegionLandGetter item,
            out RegionLand.ErrorMask errorMask,
            RegionLand.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            RegionLand ret = (RegionLand)((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).GetNew();
            ((RegionLandSetterTranslationCommon)((IRegionLandGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = RegionLand.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public RegionLand DeepCopy(
            IRegionLandGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            RegionLand ret = (RegionLand)((RegionLandCommon)((IRegionLandGetter)item).CommonInstance()!).GetNew();
            ((RegionLandSetterTranslationCommon)((IRegionLandGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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
    public partial class RegionLand
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => RegionLand_Registration.Instance;
        public new static RegionLand_Registration Registration => RegionLand_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => RegionLandCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return RegionLandSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => RegionLandSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class RegionLandBinaryWriteTranslation :
        RegionDataBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static RegionLandBinaryWriteTranslation Instance = new RegionLandBinaryWriteTranslation();

        public void Write(
            MutagenWriter writer,
            IRegionLandGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            RegionDataBinaryWriteTranslation.WriteRecordTypes(
                item: item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IRegionLandGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            IRegionDataGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IRegionLandGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class RegionLandBinaryCreateTranslation : RegionDataBinaryCreateTranslation
    {
        public new readonly static RegionLandBinaryCreateTranslation Instance = new RegionLandBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IRegionLand item,
            MutagenFrame frame)
        {
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class RegionLandBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class RegionLandBinaryOverlay :
        RegionDataBinaryOverlay,
        IRegionLandGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => RegionLand_Registration.Instance;
        public new static RegionLand_Registration Registration => RegionLand_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => RegionLandCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => RegionLandSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => RegionLandBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((RegionLandBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected RegionLandBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static RegionLandBinaryOverlay RegionLandFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new RegionLandBinaryOverlay(
                bytes: stream.RemainingMemory,
                package: package);
            int offset = stream.Position;
            ret.FillTypelessSubrecordTypes(
                stream: stream,
                finalPos: stream.Length,
                offset: offset,
                recordTypeConverter: recordTypeConverter,
                fill: ret.FillRecordType);
            return ret;
        }

        public static RegionLandBinaryOverlay RegionLandFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return RegionLandFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            RegionLandMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IRegionLandGetter rhs) return false;
            return ((RegionLandCommon)((IRegionLandGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IRegionLandGetter? obj)
        {
            return ((RegionLandCommon)((IRegionLandGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((RegionLandCommon)((IRegionLandGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

