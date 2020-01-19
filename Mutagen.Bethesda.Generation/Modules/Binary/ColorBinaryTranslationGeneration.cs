﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loqui;
using Loqui.Generation;
using Noggog;

namespace Mutagen.Bethesda.Generation
{
    public class ColorBinaryTranslationGeneration : PrimitiveBinaryTranslationGeneration<Color>
    {
        public override int? ExpectedLength(ObjectGeneration objGen, TypeGeneration typeGen)
        {
            return ExtraByte(typeGen) ? 4 : 3;
        }

        public ColorBinaryTranslationGeneration()
            : base(expectedLen: null)
        {
            this.AdditionalWriteParams.Add(AdditionalParam);
            this.AdditionalCopyInParams.Add(AdditionalParam);
            this.AdditionalCopyInRetParams.Add(AdditionalParam);
        }

        private static TryGet<string> AdditionalParam(
           ObjectGeneration objGen,
           TypeGeneration typeGen)
        {
            return TryGet<string>.Create(successful: ExtraByte(typeGen), val: "extraByte: true");
        }

        protected static bool ExtraByte(TypeGeneration typeGen)
        {
            if (!typeGen.CustomData.TryGetValue("ColorExtraByte", out var obj)) return false;
            return (bool)obj;
        }

        public override string GenerateForTypicalWrapper(ObjectGeneration objGen, TypeGeneration typeGen, Accessor dataAccessor, Accessor packageAccessor)
        {
            return $"{dataAccessor}.ReadColor()";
        }
    }
}
