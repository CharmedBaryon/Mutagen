using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Records.Binary.Streams;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Mutagen.Bethesda.Records.Binary.Translations
{
    public class ColorBinaryTranslation : PrimitiveBinaryTranslation<Color>
    {
        public readonly static ColorBinaryTranslation Instance = new ColorBinaryTranslation();
        public override int ExpectedLength => 3;

        public bool Parse(
            MutagenFrame reader,
            [MaybeNullWhen(false)]out Color item,
            ColorBinaryType binaryType)
        {
            if (binaryType != ColorBinaryType.NoAlpha)
            {
                throw new NotImplementedException();
            }
            return this.Parse(
                reader,
                out item);
        }

        public Color Parse(
            MutagenFrame reader,
            ColorBinaryType binaryType)
        {
            return reader.ReadColor(binaryType);
        }

        public override Color Parse(MutagenFrame reader)
        {
            throw new NotImplementedException();
        }

        public override void Write(MutagenWriter writer, Color item)
        {
            writer.Write(item, ColorBinaryType.Alpha);
        }

        protected Action<MutagenWriter, Color> GetWriter(ColorBinaryType binaryType)
        {
            switch (binaryType)
            {
                case ColorBinaryType.NoAlpha:
                    return (w, c) =>
                    {
                        w.Write(c, ColorBinaryType.NoAlpha);
                    };
                case ColorBinaryType.Alpha:
                    return (w, c) =>
                    {
                        w.Write(c, ColorBinaryType.Alpha);
                    };
                case ColorBinaryType.NoAlphaFloat:
                    return (w, c) =>
                    {
                        w.Write(c, ColorBinaryType.NoAlphaFloat);
                    };
                case ColorBinaryType.AlphaFloat:
                    return (w, c) =>
                    {
                        w.Write(c, ColorBinaryType.AlphaFloat);
                    };
                default:
                    throw new NotImplementedException();
            }
        }

        public void Write(
            MutagenWriter writer,
            Color item,
            RecordType header,
            ColorBinaryType binaryType)
        {
            this.Write(
                writer,
                item,
                header,
                write: GetWriter(binaryType));
        }

        public void Write(
            MutagenWriter writer,
            Color item,
            ColorBinaryType binaryType)
        {
            this.Write(
                writer,
                item,
                write: GetWriter(binaryType));
        }

        public void WriteNullable(
            MutagenWriter writer,
            Color? item,
            RecordType header,
            ColorBinaryType binaryType)
        {
            this.WriteNullable(
                writer,
                item,
                header,
                write: GetWriter(binaryType));
        }

        public void WriteNullable(
            MutagenWriter writer,
            Color? item,
            ColorBinaryType binaryType)
        {
            this.WriteNullable(
                writer,
                item,
                write: GetWriter(binaryType));
        }
    }
}