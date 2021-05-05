using System;

namespace Mutagen.Bethesda.Pex.Binary.Translations
{
    public enum VariableType : byte
    {
        Null = 0,
        Identifier = 1,
        String = 2,
        Integer = 3,
        Float = 4,
        Bool = 5
    }
}
