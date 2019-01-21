﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Tests
{
    public class Knights_Passthrough_Tests : Oblivion_Passthrough_Test
    {
        public override string Nickname => TestingConstants.KNIGHTS_ESP;
        public override ModKey ModKey => ModKey.Factory(TestingConstants.KNIGHTS_ESP);

        public Knights_Passthrough_Tests(TestingSettings settings)
            : base(
                  numMasters: 1,
                  path: Path.Combine(settings.DataFolder, settings.KnightsESP.Path))
        {
        }
    }
}