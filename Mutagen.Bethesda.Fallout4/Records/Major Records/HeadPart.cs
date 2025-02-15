using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class HeadPart
    {
        [Flags]
        public enum Flag
        {
            Playable = 0x01,
            Male = 0x02,
            Female = 0x04,
            IsExtraPart = 0x08,
            UseSolidTint = 0x10,
            UsesBodyTexture = 0x40
        }

        [Flags]
        public enum MajorFlag
        {
            NonPlayable = 0x0000_0004,
        }

        public enum TypeEnum
        {
            Misc,
            Face,
            Eyes,
            Hair,
            FacialHair,
            Scars,
            Eyebrows,
            Meatcaps,
            Teeth,
            HeadRear
        }
    }

    namespace Internals
    {
        public partial class HeadPartBinaryOverlay
        {
            public IReadOnlyList<IConditionGetter> Conditions { get; private set; } = ListExt.Empty<IConditionGetter>();

            partial void ConditionsCustomParse(OverlayStream stream, long finalPos, int offset, RecordType type, int? lastParsed)
            {
                Conditions = ConditionBinaryOverlay.ConstructBinayOverlayList(stream, _package);
            }
        }
    }
}
