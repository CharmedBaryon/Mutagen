using Mutagen.Bethesda.Records.Binary.Streams;
using Noggog;
using System;
using System.Buffers.Binary;

namespace Mutagen.Bethesda.Records.Binary.Translations
{
    public class P2IntBinaryTranslation : PrimitiveBinaryTranslation<P2Int>
    {
        public readonly static P2IntBinaryTranslation Instance = new P2IntBinaryTranslation();
        public override int ExpectedLength => 8;

        public override P2Int Parse(MutagenFrame reader)
        {
            return new P2Int(
                reader.Reader.ReadInt32(),
                reader.Reader.ReadInt32());
        }

        public override void Write(MutagenWriter writer, P2Int item)
        {
            writer.Write(item.X);
            writer.Write(item.Y);
        }

        public static P2Int Read(ReadOnlySpan<byte> span)
        {
            return new P2Int(
                BinaryPrimitives.ReadInt32LittleEndian(span),
                BinaryPrimitives.ReadInt32LittleEndian(span.Slice(4)));
        }
    }
}