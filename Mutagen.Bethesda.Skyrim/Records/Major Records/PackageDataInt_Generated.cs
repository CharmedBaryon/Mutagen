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
    public partial class PackageDataInt :
        APackageData,
        IPackageDataInt,
        ILoquiObjectSetter<PackageDataInt>,
        IEquatable<IPackageDataIntGetter>
    {
        #region Ctor
        public PackageDataInt()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Data
        public UInt32 Data { get; set; } = default;
        #endregion

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            PackageDataIntMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is IPackageDataIntGetter rhs)) return false;
            return ((PackageDataIntCommon)((IPackageDataIntGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(IPackageDataIntGetter? obj)
        {
            return ((PackageDataIntCommon)((IPackageDataIntGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((PackageDataIntCommon)((IPackageDataIntGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            APackageData.Mask<TItem>,
            IMask<TItem>,
            IEquatable<Mask<TItem>>
        {
            #region Ctors
            public Mask(TItem initialValue)
            : base(initialValue)
            {
                this.Data = initialValue;
            }

            public Mask(
                TItem Name,
                TItem Flags,
                TItem Data)
            : base(
                Name: Name,
                Flags: Flags)
            {
                this.Data = Data;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Data;
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
                if (!object.Equals(this.Data, rhs.Data)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Data);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.Data)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.Data)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new PackageDataInt.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.Data = eval(this.Data);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(PackageDataInt.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, PackageDataInt.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(PackageDataInt.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Data ?? true)
                    {
                        fg.AppendItem(Data, "Data");
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            APackageData.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Data;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                PackageDataInt_FieldIndex enu = (PackageDataInt_FieldIndex)index;
                switch (enu)
                {
                    case PackageDataInt_FieldIndex.Data:
                        return Data;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                PackageDataInt_FieldIndex enu = (PackageDataInt_FieldIndex)index;
                switch (enu)
                {
                    case PackageDataInt_FieldIndex.Data:
                        this.Data = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                PackageDataInt_FieldIndex enu = (PackageDataInt_FieldIndex)index;
                switch (enu)
                {
                    case PackageDataInt_FieldIndex.Data:
                        this.Data = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (Data != null) return true;
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
                fg.AppendItem(Data, "Data");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Data = this.Data.Combine(rhs.Data);
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
            APackageData.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool Data;
            #endregion

            #region Ctors
            public TranslationMask(bool defaultOn)
                : base(defaultOn)
            {
                this.Data = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((Data, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => PackageDataIntBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((PackageDataIntBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public new static PackageDataInt CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new PackageDataInt();
            ((PackageDataIntSetterCommon)((IPackageDataIntGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out PackageDataInt item,
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
            ((PackageDataIntSetterCommon)((IPackageDataIntGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new PackageDataInt GetNew()
        {
            return new PackageDataInt();
        }

    }
    #endregion

    #region Interface
    public partial interface IPackageDataInt :
        IPackageDataIntGetter,
        IAPackageData,
        ILoquiObjectSetter<IPackageDataInt>
    {
        new UInt32 Data { get; set; }
    }

    public partial interface IPackageDataIntGetter :
        IAPackageDataGetter,
        ILoquiObject<IPackageDataIntGetter>,
        IBinaryItem
    {
        static new ILoquiRegistration Registration => PackageDataInt_Registration.Instance;
        UInt32 Data { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class PackageDataIntMixIn
    {
        public static void Clear(this IPackageDataInt item)
        {
            ((PackageDataIntSetterCommon)((IPackageDataIntGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static PackageDataInt.Mask<bool> GetEqualsMask(
            this IPackageDataIntGetter item,
            IPackageDataIntGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IPackageDataIntGetter item,
            string? name = null,
            PackageDataInt.Mask<bool>? printMask = null)
        {
            return ((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IPackageDataIntGetter item,
            FileGeneration fg,
            string? name = null,
            PackageDataInt.Mask<bool>? printMask = null)
        {
            ((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IPackageDataIntGetter item,
            IPackageDataIntGetter rhs)
        {
            return ((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs);
        }

        public static void DeepCopyIn(
            this IPackageDataInt lhs,
            IPackageDataIntGetter rhs,
            out PackageDataInt.ErrorMask errorMask,
            PackageDataInt.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = PackageDataInt.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IPackageDataInt lhs,
            IPackageDataIntGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static PackageDataInt DeepCopy(
            this IPackageDataIntGetter item,
            PackageDataInt.TranslationMask? copyMask = null)
        {
            return ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static PackageDataInt DeepCopy(
            this IPackageDataIntGetter item,
            out PackageDataInt.ErrorMask errorMask,
            PackageDataInt.TranslationMask? copyMask = null)
        {
            return ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static PackageDataInt DeepCopy(
            this IPackageDataIntGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IPackageDataInt item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((PackageDataIntSetterCommon)((IPackageDataIntGetter)item).CommonSetterInstance()!).CopyInFromBinary(
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
    public enum PackageDataInt_FieldIndex
    {
        Name = 0,
        Flags = 1,
        Data = 2,
    }
    #endregion

    #region Registration
    public partial class PackageDataInt_Registration : ILoquiRegistration
    {
        public static readonly PackageDataInt_Registration Instance = new PackageDataInt_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 388,
            version: 0);

        public const string GUID = "9ed95e65-b720-44db-9d2b-be2bb15ca173";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 3;

        public static readonly Type MaskType = typeof(PackageDataInt.Mask<>);

        public static readonly Type ErrorMaskType = typeof(PackageDataInt.ErrorMask);

        public static readonly Type ClassType = typeof(PackageDataInt);

        public static readonly Type GetterType = typeof(IPackageDataIntGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IPackageDataInt);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.PackageDataInt";

        public const string Name = "PackageDataInt";

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
                        RecordTypes.BNAM,
                        RecordTypes.PNAM
                    })
            );
        });
        public static readonly Type BinaryWriteTranslation = typeof(PackageDataIntBinaryWriteTranslation);
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
    public partial class PackageDataIntSetterCommon : APackageDataSetterCommon
    {
        public new static readonly PackageDataIntSetterCommon Instance = new PackageDataIntSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IPackageDataInt item)
        {
            ClearPartial();
            item.Data = default;
            base.Clear(item);
        }
        
        public override void Clear(IAPackageData item)
        {
            Clear(item: (IPackageDataInt)item);
        }
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IPackageDataInt item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            UtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: PackageDataIntBinaryCreateTranslation.FillBinaryStructs,
                fillTyped: PackageDataIntBinaryCreateTranslation.FillBinaryRecordTypes);
        }
        
        public override void CopyInFromBinary(
            IAPackageData item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (PackageDataInt)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        #endregion
        
    }
    public partial class PackageDataIntCommon : APackageDataCommon
    {
        public new static readonly PackageDataIntCommon Instance = new PackageDataIntCommon();

        public PackageDataInt.Mask<bool> GetEqualsMask(
            IPackageDataIntGetter item,
            IPackageDataIntGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new PackageDataInt.Mask<bool>(false);
            ((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IPackageDataIntGetter item,
            IPackageDataIntGetter rhs,
            PackageDataInt.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Data = item.Data == rhs.Data;
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            IPackageDataIntGetter item,
            string? name = null,
            PackageDataInt.Mask<bool>? printMask = null)
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
            IPackageDataIntGetter item,
            FileGeneration fg,
            string? name = null,
            PackageDataInt.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"PackageDataInt =>");
            }
            else
            {
                fg.AppendLine($"{name} (PackageDataInt) =>");
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
            IPackageDataIntGetter item,
            FileGeneration fg,
            PackageDataInt.Mask<bool>? printMask = null)
        {
            APackageDataCommon.ToStringFields(
                item: item,
                fg: fg,
                printMask: printMask);
            if (printMask?.Data ?? true)
            {
                fg.AppendItem(item.Data, "Data");
            }
        }
        
        public static PackageDataInt_FieldIndex ConvertFieldIndex(APackageData_FieldIndex index)
        {
            switch (index)
            {
                case APackageData_FieldIndex.Name:
                    return (PackageDataInt_FieldIndex)((int)index);
                case APackageData_FieldIndex.Flags:
                    return (PackageDataInt_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IPackageDataIntGetter? lhs,
            IPackageDataIntGetter? rhs)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if (!base.Equals((IAPackageDataGetter)lhs, (IAPackageDataGetter)rhs)) return false;
            if (lhs.Data != rhs.Data) return false;
            return true;
        }
        
        public override bool Equals(
            IAPackageDataGetter? lhs,
            IAPackageDataGetter? rhs)
        {
            return Equals(
                lhs: (IPackageDataIntGetter?)lhs,
                rhs: rhs as IPackageDataIntGetter);
        }
        
        public virtual int GetHashCode(IPackageDataIntGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Data);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IAPackageDataGetter item)
        {
            return GetHashCode(item: (IPackageDataIntGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return PackageDataInt.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormKey> GetLinkFormKeys(IPackageDataIntGetter obj)
        {
            foreach (var item in base.GetLinkFormKeys(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        public void RemapLinks(IPackageDataIntGetter obj, IReadOnlyDictionary<FormKey, FormKey> mapping) => throw new NotImplementedException();
        #endregion
        
    }
    public partial class PackageDataIntSetterTranslationCommon : APackageDataSetterTranslationCommon
    {
        public new static readonly PackageDataIntSetterTranslationCommon Instance = new PackageDataIntSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IPackageDataInt item,
            IPackageDataIntGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IAPackageData)item,
                (IAPackageDataGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)PackageDataInt_FieldIndex.Data) ?? true))
            {
                item.Data = rhs.Data;
            }
        }
        
        
        public override void DeepCopyIn(
            IAPackageData item,
            IAPackageDataGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IPackageDataInt)item,
                rhs: (IPackageDataIntGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public PackageDataInt DeepCopy(
            IPackageDataIntGetter item,
            PackageDataInt.TranslationMask? copyMask = null)
        {
            PackageDataInt ret = (PackageDataInt)((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).GetNew();
            ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public PackageDataInt DeepCopy(
            IPackageDataIntGetter item,
            out PackageDataInt.ErrorMask errorMask,
            PackageDataInt.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            PackageDataInt ret = (PackageDataInt)((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).GetNew();
            ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = PackageDataInt.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public PackageDataInt DeepCopy(
            IPackageDataIntGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            PackageDataInt ret = (PackageDataInt)((PackageDataIntCommon)((IPackageDataIntGetter)item).CommonInstance()!).GetNew();
            ((PackageDataIntSetterTranslationCommon)((IPackageDataIntGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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
    public partial class PackageDataInt
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => PackageDataInt_Registration.Instance;
        public new static PackageDataInt_Registration Registration => PackageDataInt_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => PackageDataIntCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return PackageDataIntSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => PackageDataIntSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class PackageDataIntBinaryWriteTranslation :
        APackageDataBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static PackageDataIntBinaryWriteTranslation Instance = new PackageDataIntBinaryWriteTranslation();

        public static void WriteEmbedded(
            IPackageDataIntGetter item,
            MutagenWriter writer)
        {
        }

        public void Write(
            MutagenWriter writer,
            IPackageDataIntGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
            APackageDataBinaryWriteTranslation.WriteRecordTypes(
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
                item: (IPackageDataIntGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            IAPackageDataGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IPackageDataIntGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class PackageDataIntBinaryCreateTranslation : APackageDataBinaryCreateTranslation
    {
        public new readonly static PackageDataIntBinaryCreateTranslation Instance = new PackageDataIntBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IPackageDataInt item,
            MutagenFrame frame)
        {
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class PackageDataIntBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class PackageDataIntBinaryOverlay :
        APackageDataBinaryOverlay,
        IPackageDataIntGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => PackageDataInt_Registration.Instance;
        public new static PackageDataInt_Registration Registration => PackageDataInt_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => PackageDataIntCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => PackageDataIntSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => PackageDataIntBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((PackageDataIntBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected PackageDataIntBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static PackageDataIntBinaryOverlay PackageDataIntFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new PackageDataIntBinaryOverlay(
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

        public static PackageDataIntBinaryOverlay PackageDataIntFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return PackageDataIntFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            PackageDataIntMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is IPackageDataIntGetter rhs)) return false;
            return ((PackageDataIntCommon)((IPackageDataIntGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(IPackageDataIntGetter? obj)
        {
            return ((PackageDataIntCommon)((IPackageDataIntGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((PackageDataIntCommon)((IPackageDataIntGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

