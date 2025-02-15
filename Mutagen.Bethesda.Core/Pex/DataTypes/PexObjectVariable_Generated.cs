/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Pex;
using Mutagen.Bethesda.Pex.Internals;
using Noggog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Pex
{
    #region Class
    public partial class PexObjectVariable :
        IEquatable<IPexObjectVariableGetter>,
        ILoquiObjectSetter<PexObjectVariable>,
        IPexObjectVariable
    {
        #region Ctor
        public PexObjectVariable()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Name
        public String? Name { get; set; }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        String? IPexObjectVariableGetter.Name => this.Name;
        #endregion
        #region TypeName
        public String? TypeName { get; set; }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        String? IPexObjectVariableGetter.TypeName => this.TypeName;
        #endregion
        #region RawUserFlags
        public UInt32 RawUserFlags { get; set; } = default;
        #endregion
        #region VariableData
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PexObjectVariableData? _VariableData;
        public PexObjectVariableData? VariableData
        {
            get => _VariableData;
            set => _VariableData = value;
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IPexObjectVariableDataGetter? IPexObjectVariableGetter.VariableData => this.VariableData;
        #endregion

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            PexObjectVariableMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IPexObjectVariableGetter rhs) return false;
            return ((PexObjectVariableCommon)((IPexObjectVariableGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IPexObjectVariableGetter? obj)
        {
            return ((PexObjectVariableCommon)((IPexObjectVariableGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((PexObjectVariableCommon)((IPexObjectVariableGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public class Mask<TItem> :
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
            {
                this.Name = initialValue;
                this.TypeName = initialValue;
                this.RawUserFlags = initialValue;
                this.VariableData = new MaskItem<TItem, PexObjectVariableData.Mask<TItem>?>(initialValue, new PexObjectVariableData.Mask<TItem>(initialValue));
            }

            public Mask(
                TItem Name,
                TItem TypeName,
                TItem RawUserFlags,
                TItem VariableData)
            {
                this.Name = Name;
                this.TypeName = TypeName;
                this.RawUserFlags = RawUserFlags;
                this.VariableData = new MaskItem<TItem, PexObjectVariableData.Mask<TItem>?>(VariableData, new PexObjectVariableData.Mask<TItem>(VariableData));
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Name;
            public TItem TypeName;
            public TItem RawUserFlags;
            public MaskItem<TItem, PexObjectVariableData.Mask<TItem>?>? VariableData { get; set; }
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
                if (!object.Equals(this.Name, rhs.Name)) return false;
                if (!object.Equals(this.TypeName, rhs.TypeName)) return false;
                if (!object.Equals(this.RawUserFlags, rhs.RawUserFlags)) return false;
                if (!object.Equals(this.VariableData, rhs.VariableData)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Name);
                hash.Add(this.TypeName);
                hash.Add(this.RawUserFlags);
                hash.Add(this.VariableData);
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public bool All(Func<TItem, bool> eval)
            {
                if (!eval(this.Name)) return false;
                if (!eval(this.TypeName)) return false;
                if (!eval(this.RawUserFlags)) return false;
                if (VariableData != null)
                {
                    if (!eval(this.VariableData.Overall)) return false;
                    if (this.VariableData.Specific != null && !this.VariableData.Specific.All(eval)) return false;
                }
                return true;
            }
            #endregion

            #region Any
            public bool Any(Func<TItem, bool> eval)
            {
                if (eval(this.Name)) return true;
                if (eval(this.TypeName)) return true;
                if (eval(this.RawUserFlags)) return true;
                if (VariableData != null)
                {
                    if (eval(this.VariableData.Overall)) return true;
                    if (this.VariableData.Specific != null && this.VariableData.Specific.Any(eval)) return true;
                }
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new PexObjectVariable.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                obj.Name = eval(this.Name);
                obj.TypeName = eval(this.TypeName);
                obj.RawUserFlags = eval(this.RawUserFlags);
                obj.VariableData = this.VariableData == null ? null : new MaskItem<R, PexObjectVariableData.Mask<R>?>(eval(this.VariableData.Overall), this.VariableData.Specific?.Translate(eval));
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(PexObjectVariable.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, PexObjectVariable.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(PexObjectVariable.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Name ?? true)
                    {
                        fg.AppendItem(Name, "Name");
                    }
                    if (printMask?.TypeName ?? true)
                    {
                        fg.AppendItem(TypeName, "TypeName");
                    }
                    if (printMask?.RawUserFlags ?? true)
                    {
                        fg.AppendItem(RawUserFlags, "RawUserFlags");
                    }
                    if (printMask?.VariableData?.Overall ?? true)
                    {
                        VariableData?.ToString(fg);
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public class ErrorMask :
            IErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Overall { get; set; }
            private List<string>? _warnings;
            public List<string> Warnings
            {
                get
                {
                    if (_warnings == null)
                    {
                        _warnings = new List<string>();
                    }
                    return _warnings;
                }
            }
            public Exception? Name;
            public Exception? TypeName;
            public Exception? RawUserFlags;
            public MaskItem<Exception?, PexObjectVariableData.ErrorMask?>? VariableData;
            #endregion

            #region IErrorMask
            public object? GetNthMask(int index)
            {
                PexObjectVariable_FieldIndex enu = (PexObjectVariable_FieldIndex)index;
                switch (enu)
                {
                    case PexObjectVariable_FieldIndex.Name:
                        return Name;
                    case PexObjectVariable_FieldIndex.TypeName:
                        return TypeName;
                    case PexObjectVariable_FieldIndex.RawUserFlags:
                        return RawUserFlags;
                    case PexObjectVariable_FieldIndex.VariableData:
                        return VariableData;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthException(int index, Exception ex)
            {
                PexObjectVariable_FieldIndex enu = (PexObjectVariable_FieldIndex)index;
                switch (enu)
                {
                    case PexObjectVariable_FieldIndex.Name:
                        this.Name = ex;
                        break;
                    case PexObjectVariable_FieldIndex.TypeName:
                        this.TypeName = ex;
                        break;
                    case PexObjectVariable_FieldIndex.RawUserFlags:
                        this.RawUserFlags = ex;
                        break;
                    case PexObjectVariable_FieldIndex.VariableData:
                        this.VariableData = new MaskItem<Exception?, PexObjectVariableData.ErrorMask?>(ex, null);
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthMask(int index, object obj)
            {
                PexObjectVariable_FieldIndex enu = (PexObjectVariable_FieldIndex)index;
                switch (enu)
                {
                    case PexObjectVariable_FieldIndex.Name:
                        this.Name = (Exception?)obj;
                        break;
                    case PexObjectVariable_FieldIndex.TypeName:
                        this.TypeName = (Exception?)obj;
                        break;
                    case PexObjectVariable_FieldIndex.RawUserFlags:
                        this.RawUserFlags = (Exception?)obj;
                        break;
                    case PexObjectVariable_FieldIndex.VariableData:
                        this.VariableData = (MaskItem<Exception?, PexObjectVariableData.ErrorMask?>?)obj;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public bool IsInError()
            {
                if (Overall != null) return true;
                if (Name != null) return true;
                if (TypeName != null) return true;
                if (RawUserFlags != null) return true;
                if (VariableData != null) return true;
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

            public void ToString(FileGeneration fg, string? name = null)
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
            protected void ToString_FillInternal(FileGeneration fg)
            {
                fg.AppendItem(Name, "Name");
                fg.AppendItem(TypeName, "TypeName");
                fg.AppendItem(RawUserFlags, "RawUserFlags");
                VariableData?.ToString(fg);
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Name = this.Name.Combine(rhs.Name);
                ret.TypeName = this.TypeName.Combine(rhs.TypeName);
                ret.RawUserFlags = this.RawUserFlags.Combine(rhs.RawUserFlags);
                ret.VariableData = this.VariableData.Combine(rhs.VariableData, (l, r) => l.Combine(r));
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public class TranslationMask : ITranslationMask
        {
            #region Members
            private TranslationCrystal? _crystal;
            public readonly bool DefaultOn;
            public bool OnOverall;
            public bool Name;
            public bool TypeName;
            public bool RawUserFlags;
            public PexObjectVariableData.TranslationMask? VariableData;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
            {
                this.DefaultOn = defaultOn;
                this.OnOverall = onOverall;
                this.Name = defaultOn;
                this.TypeName = defaultOn;
                this.RawUserFlags = defaultOn;
            }

            #endregion

            public TranslationCrystal GetCrystal()
            {
                if (_crystal != null) return _crystal;
                var ret = new List<(bool On, TranslationCrystal? SubCrystal)>();
                GetCrystal(ret);
                _crystal = new TranslationCrystal(ret.ToArray());
                return _crystal;
            }

            protected void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                ret.Add((Name, null));
                ret.Add((TypeName, null));
                ret.Add((RawUserFlags, null));
                ret.Add((VariableData != null ? VariableData.OnOverall : DefaultOn, VariableData?.GetCrystal()));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((PexObjectVariableSetterCommon)((IPexObjectVariableGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static PexObjectVariable GetNew()
        {
            return new PexObjectVariable();
        }

    }
    #endregion

    #region Interface
    public partial interface IPexObjectVariable :
        IHasUserFlags,
        ILoquiObjectSetter<IPexObjectVariable>,
        IPexObjectVariableGetter
    {
        new String? Name { get; set; }
        new String? TypeName { get; set; }
        new UInt32 RawUserFlags { get; set; }
        new PexObjectVariableData? VariableData { get; set; }
    }

    public partial interface IPexObjectVariableGetter :
        ILoquiObject,
        IHasUserFlagsGetter,
        ILoquiObject<IPexObjectVariableGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration Registration => PexObjectVariable_Registration.Instance;
        String? Name { get; }
        String? TypeName { get; }
        UInt32 RawUserFlags { get; }
        IPexObjectVariableDataGetter? VariableData { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class PexObjectVariableMixIn
    {
        public static void Clear(this IPexObjectVariable item)
        {
            ((PexObjectVariableSetterCommon)((IPexObjectVariableGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static PexObjectVariable.Mask<bool> GetEqualsMask(
            this IPexObjectVariableGetter item,
            IPexObjectVariableGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IPexObjectVariableGetter item,
            string? name = null,
            PexObjectVariable.Mask<bool>? printMask = null)
        {
            return ((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IPexObjectVariableGetter item,
            FileGeneration fg,
            string? name = null,
            PexObjectVariable.Mask<bool>? printMask = null)
        {
            ((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IPexObjectVariableGetter item,
            IPexObjectVariableGetter rhs,
            PexObjectVariable.TranslationMask? equalsMask = null)
        {
            return ((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IPexObjectVariable lhs,
            IPexObjectVariableGetter rhs)
        {
            ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IPexObjectVariable lhs,
            IPexObjectVariableGetter rhs,
            PexObjectVariable.TranslationMask? copyMask = null)
        {
            ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IPexObjectVariable lhs,
            IPexObjectVariableGetter rhs,
            out PexObjectVariable.ErrorMask errorMask,
            PexObjectVariable.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = PexObjectVariable.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IPexObjectVariable lhs,
            IPexObjectVariableGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static PexObjectVariable DeepCopy(
            this IPexObjectVariableGetter item,
            PexObjectVariable.TranslationMask? copyMask = null)
        {
            return ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static PexObjectVariable DeepCopy(
            this IPexObjectVariableGetter item,
            out PexObjectVariable.ErrorMask errorMask,
            PexObjectVariable.TranslationMask? copyMask = null)
        {
            return ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static PexObjectVariable DeepCopy(
            this IPexObjectVariableGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

    }
    #endregion

}

namespace Mutagen.Bethesda.Pex.Internals
{
    #region Field Index
    public enum PexObjectVariable_FieldIndex
    {
        Name = 0,
        TypeName = 1,
        RawUserFlags = 2,
        VariableData = 3,
    }
    #endregion

    #region Registration
    public partial class PexObjectVariable_Registration : ILoquiRegistration
    {
        public static readonly PexObjectVariable_Registration Instance = new PexObjectVariable_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Pex.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Pex.ProtocolKey,
            msgID: 9,
            version: 0);

        public const string GUID = "dcbe94f2-dda2-47b9-9057-e30c6c8fac8c";

        public const ushort AdditionalFieldCount = 4;

        public const ushort FieldCount = 4;

        public static readonly Type MaskType = typeof(PexObjectVariable.Mask<>);

        public static readonly Type ErrorMaskType = typeof(PexObjectVariable.ErrorMask);

        public static readonly Type ClassType = typeof(PexObjectVariable);

        public static readonly Type GetterType = typeof(IPexObjectVariableGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IPexObjectVariable);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Pex.PexObjectVariable";

        public const string Name = "PexObjectVariable";

        public const string Namespace = "Mutagen.Bethesda.Pex";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

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
    public partial class PexObjectVariableSetterCommon
    {
        public static readonly PexObjectVariableSetterCommon Instance = new PexObjectVariableSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IPexObjectVariable item)
        {
            ClearPartial();
            item.Name = default;
            item.TypeName = default;
            item.RawUserFlags = default;
            item.VariableData = null;
        }
        
    }
    public partial class PexObjectVariableCommon
    {
        public static readonly PexObjectVariableCommon Instance = new PexObjectVariableCommon();

        public PexObjectVariable.Mask<bool> GetEqualsMask(
            IPexObjectVariableGetter item,
            IPexObjectVariableGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new PexObjectVariable.Mask<bool>(false);
            ((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IPexObjectVariableGetter item,
            IPexObjectVariableGetter rhs,
            PexObjectVariable.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Name = string.Equals(item.Name, rhs.Name);
            ret.TypeName = string.Equals(item.TypeName, rhs.TypeName);
            ret.RawUserFlags = item.RawUserFlags == rhs.RawUserFlags;
            ret.VariableData = EqualsMaskHelper.EqualsHelper(
                item.VariableData,
                rhs.VariableData,
                (loqLhs, loqRhs, incl) => loqLhs.GetEqualsMask(loqRhs, incl),
                include);
        }
        
        public string ToString(
            IPexObjectVariableGetter item,
            string? name = null,
            PexObjectVariable.Mask<bool>? printMask = null)
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
            IPexObjectVariableGetter item,
            FileGeneration fg,
            string? name = null,
            PexObjectVariable.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"PexObjectVariable =>");
            }
            else
            {
                fg.AppendLine($"{name} (PexObjectVariable) =>");
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
            IPexObjectVariableGetter item,
            FileGeneration fg,
            PexObjectVariable.Mask<bool>? printMask = null)
        {
            if ((printMask?.Name ?? true)
                && item.Name.TryGet(out var NameItem))
            {
                fg.AppendItem(NameItem, "Name");
            }
            if ((printMask?.TypeName ?? true)
                && item.TypeName.TryGet(out var TypeNameItem))
            {
                fg.AppendItem(TypeNameItem, "TypeName");
            }
            if (printMask?.RawUserFlags ?? true)
            {
                fg.AppendItem(item.RawUserFlags, "RawUserFlags");
            }
            if ((printMask?.VariableData?.Overall ?? true)
                && item.VariableData.TryGet(out var VariableDataItem))
            {
                VariableDataItem?.ToString(fg, "VariableData");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IPexObjectVariableGetter? lhs,
            IPexObjectVariableGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if ((crystal?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.Name) ?? true))
            {
                if (!string.Equals(lhs.Name, rhs.Name)) return false;
            }
            if ((crystal?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.TypeName) ?? true))
            {
                if (!string.Equals(lhs.TypeName, rhs.TypeName)) return false;
            }
            if ((crystal?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.RawUserFlags) ?? true))
            {
                if (lhs.RawUserFlags != rhs.RawUserFlags) return false;
            }
            if ((crystal?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.VariableData) ?? true))
            {
                if (!object.Equals(lhs.VariableData, rhs.VariableData)) return false;
            }
            return true;
        }
        
        public virtual int GetHashCode(IPexObjectVariableGetter item)
        {
            var hash = new HashCode();
            if (item.Name.TryGet(out var Nameitem))
            {
                hash.Add(Nameitem);
            }
            if (item.TypeName.TryGet(out var TypeNameitem))
            {
                hash.Add(TypeNameitem);
            }
            hash.Add(item.RawUserFlags);
            if (item.VariableData.TryGet(out var VariableDataitem))
            {
                hash.Add(VariableDataitem);
            }
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public object GetNew()
        {
            return PexObjectVariable.GetNew();
        }
        
    }
    public partial class PexObjectVariableSetterTranslationCommon
    {
        public static readonly PexObjectVariableSetterTranslationCommon Instance = new PexObjectVariableSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IPexObjectVariable item,
            IPexObjectVariableGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            if ((copyMask?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.Name) ?? true))
            {
                item.Name = rhs.Name;
            }
            if ((copyMask?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.TypeName) ?? true))
            {
                item.TypeName = rhs.TypeName;
            }
            if ((copyMask?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.RawUserFlags) ?? true))
            {
                item.RawUserFlags = rhs.RawUserFlags;
            }
            if ((copyMask?.GetShouldTranslate((int)PexObjectVariable_FieldIndex.VariableData) ?? true))
            {
                errorMask?.PushIndex((int)PexObjectVariable_FieldIndex.VariableData);
                try
                {
                    if(rhs.VariableData.TryGet(out var rhsVariableData))
                    {
                        item.VariableData = rhsVariableData.DeepCopy(
                            errorMask: errorMask,
                            copyMask?.GetSubCrystal((int)PexObjectVariable_FieldIndex.VariableData));
                    }
                    else
                    {
                        item.VariableData = default;
                    }
                }
                catch (Exception ex)
                when (errorMask != null)
                {
                    errorMask.ReportException(ex);
                }
                finally
                {
                    errorMask?.PopIndex();
                }
            }
        }
        
        #endregion
        
        public PexObjectVariable DeepCopy(
            IPexObjectVariableGetter item,
            PexObjectVariable.TranslationMask? copyMask = null)
        {
            PexObjectVariable ret = (PexObjectVariable)((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).GetNew();
            ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public PexObjectVariable DeepCopy(
            IPexObjectVariableGetter item,
            out PexObjectVariable.ErrorMask errorMask,
            PexObjectVariable.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            PexObjectVariable ret = (PexObjectVariable)((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).GetNew();
            ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = PexObjectVariable.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public PexObjectVariable DeepCopy(
            IPexObjectVariableGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            PexObjectVariable ret = (PexObjectVariable)((PexObjectVariableCommon)((IPexObjectVariableGetter)item).CommonInstance()!).GetNew();
            ((PexObjectVariableSetterTranslationCommon)((IPexObjectVariableGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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

namespace Mutagen.Bethesda.Pex
{
    public partial class PexObjectVariable
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => PexObjectVariable_Registration.Instance;
        public static PexObjectVariable_Registration Registration => PexObjectVariable_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => PexObjectVariableCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterInstance()
        {
            return PexObjectVariableSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => PexObjectVariableSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IPexObjectVariableGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object IPexObjectVariableGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object IPexObjectVariableGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

