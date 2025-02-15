using Loqui.Generation;
using Noggog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Loqui;

namespace Mutagen.Bethesda.Generation.Modules.Aspects
{
    public class AspectInterfaceModule : GenerationModule
    {
        public List<AspectInterfaceDefinition> Definitions = new();
        public static readonly Dictionary<ProtocolKey, Dictionary<AspectInterfaceDefinition, List<ObjectGeneration>>> ObjectMappings = new();

        public AspectInterfaceModule()
        {
            Definitions.Add(new KeywordedAspect());
            Definitions.Add(new KeywordAspect());
            Definitions.Add(new NamedAspect());
            Definitions.Add(new ObjectBoundedAspect());
            Definitions.Add(new RefAspect("IScripted", "VirtualMachineAdapter", "VirtualMachineAdapter"));
            Definitions.Add(new RefAspect("IModeled", "Model", "Model"));
            Definitions.Add(new RefAspect("IHasIcons", "Icons", "Icons"));
            Definitions.Add(new FieldsAspect("IWeightValue",
                ("Value", "UInt32"),
                ("Weight", "Single")));
        }

        public override async Task LoadWrapup(ObjectGeneration obj)
        {
            await obj.GetObjectData().WiringComplete.Task;
            var allFields = obj.IterateFields(includeBaseClass: true).ToDictionary(x => x.Name);
            foreach (var def in Definitions)
            {
                if (!def.Test(obj, allFields)) continue;
                def.Interfaces(obj).ForEach(x => obj.Interfaces.Add(x.Type, x.Interface));
                lock (ObjectMappings)
                {
                    ObjectMappings.GetOrAdd(obj.ProtoGen.Protocol).GetOrAdd(def).Add(obj);
                }
            }
        }

        public override async Task GenerateInField(ObjectGeneration obj, TypeGeneration tg, FileGeneration fg, LoquiInterfaceType type)
        {
            using (new RegionWrapper(fg, "Aspects")
            {
                AppendExtraLine = false,
                SkipIfOnlyOneLine = true,
            })
            {
                var allFields = obj.IterateFields(includeBaseClass: true).ToDictionary(x => x.Name);
                foreach (var def in Definitions.OfType<AspectFieldInterfaceDefinition>())
                {
                    if (!def.Test(obj, allFields)) continue;
                    def.FieldActions
                        .Where(x => x.Type == type && tg.Name == x.Name)
                        .ForEach(x => x.Actions(obj, tg, fg));
                }
            }
        }

        public override async Task PostLoad(ObjectGeneration obj)
        {
            Dictionary<LoquiInterfaceDefinitionType, HashSet<string>>? aspects = null;
            Dictionary<string, (TypeGeneration type, Dictionary<LoquiInterfaceDefinitionType, HashSet<string>> aspects)>? fieldsToAspects = null;

            var allFields = obj.IterateFields(includeBaseClass: true).ToDictionary(x => x.Name);

            foreach (var def in Definitions)
                if (def.Test(obj, allFields))
                {
                    var interfaces = def.Interfaces(obj);
                    if (def is AspectFieldInterfaceDefinition fieldDef)
                        foreach (var f in fieldDef.IdentifyFields(obj))
                            RecordAspects((fieldsToAspects ??= new()).GetOrAdd(f.Name, () => new(f, new())).aspects, interfaces);
                    else
                        RecordAspects(aspects ??= new(), interfaces);
                }

            if (aspects is not null)
                AddAspectComment(aspects, obj.Comments ??= new());

            if (fieldsToAspects is not null)
                foreach (var (type, typeAspects) in fieldsToAspects.Values)
                    AddAspectComment(typeAspects, type.Comments ??= new());
        }

        private static void RecordAspects(Dictionary<LoquiInterfaceDefinitionType, HashSet<string>> aspects, IEnumerable<AspectInterfaceData> interfaces)
        {
            foreach (var (type, _, escapedInterfaceName) in interfaces)
                switch (type)
                {
                    case LoquiInterfaceDefinitionType.Direct:
                    case LoquiInterfaceDefinitionType.IGetter:
                        aspects.GetOrAdd(type).Add(escapedInterfaceName);
                        break;
                    case LoquiInterfaceDefinitionType.ISetter:
                        aspects.GetOrAdd(type).Add(escapedInterfaceName);
                        aspects.GetOrAdd(LoquiInterfaceDefinitionType.Direct).Add(escapedInterfaceName);
                        break;
                    case LoquiInterfaceDefinitionType.Dual:
                        aspects.GetOrAdd(LoquiInterfaceDefinitionType.Direct).Add(escapedInterfaceName);
                        aspects.GetOrAdd(LoquiInterfaceDefinitionType.ISetter).Add(escapedInterfaceName);
                        aspects.GetOrAdd(LoquiInterfaceDefinitionType.IGetter).Add(escapedInterfaceName);
                        break;
                    default:
                        break;
                }
        }

        private static void AddAspectComment(Dictionary<LoquiInterfaceDefinitionType, HashSet<string>> aspects, CommentCollection comments)
        {
            foreach (var item in aspects)
            {
                FileGeneration summary = (item.Key switch
                {
                    LoquiInterfaceDefinitionType.IGetter => (comments.GetterInterface ??= new(null!)).Summary,
                    LoquiInterfaceDefinitionType.ISetter => (comments.SetterInterface ??= new(null!)).Summary,
                    _ => comments.Comments.Summary,
                });
                if (!summary.Empty)
                    summary.AppendLine("<br />");
                summary.AppendLine("Aspects: " + string.Join(", ", item.Value.OrderBy(x => x)));
            }
        }
    }
}
