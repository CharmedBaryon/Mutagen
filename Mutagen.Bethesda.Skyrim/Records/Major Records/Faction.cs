using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Noggog;

namespace Mutagen.Bethesda.Skyrim
{
    public partial class Faction
    {
        [Flags]
        public enum FactionFlag
        {
            HiddenFromPC = 0x0_0001,
            SpecialCombat = 0x0_0002,
            TrackCrime = 0x0_0040,
            IgnoreMurder = 0x0_0080,
            IgnoreAssault = 0x0_0100,
            IgnoreStealing = 0x0_0200,
            IgnoreTrespass = 0x0_0400,
            DoNotReportCrimesAgainstMembers = 0x0_0800,
            CrimeGoldUseDefaults = 0x0_1000,
            IgnorePickpocket = 0x0_2000,
            Vendor = 0x0_4000,
            CanBeOwner = 0x0_8000,
            IgnoreWerewolf = 0x1_0000,
        }
    }

    namespace Internals
    {
        public partial class FactionBinaryOverlay
        {
            public IReadOnlyList<IConditionGetter>? Conditions { get; private set; }

            partial void ConditionsCustomParse(OverlayStream stream, long finalPos, int offset, RecordType type, int? lastParsed)
            {
                Conditions = ConditionBinaryOverlay.ConstructBinayOverlayCountedList(stream, _package);
            }
        }
    }
}
