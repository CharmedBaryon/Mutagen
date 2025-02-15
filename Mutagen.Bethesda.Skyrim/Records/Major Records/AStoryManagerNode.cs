using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Skyrim
{
    public partial class AStoryManagerNode
    {
        [Flags]
        public enum Flag
        {
            Random = 0x01,
            WarnIfNoChildQuestStarted = 0x02,
        }
    }

    namespace Internals
    {
        public partial class AStoryManagerNodeBinaryOverlay
        {
            public IReadOnlyList<IConditionGetter> Conditions { get; private set; } = ListExt.Empty<IConditionGetter>();

            partial void ConditionsCustomParse(OverlayStream stream, long finalPos, int offset, RecordType type, int? lastParsed)
            {
                Conditions = ConditionBinaryOverlay.ConstructBinayOverlayCountedList(stream, _package);
            }
        }
    }
}
