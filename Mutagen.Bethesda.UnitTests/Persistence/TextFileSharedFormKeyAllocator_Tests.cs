using Mutagen.Bethesda.Persistence;
using Mutagen.Bethesda.Oblivion;
using System;
using System.IO;
using Xunit;

namespace Mutagen.Bethesda.UnitTests.Persistence
{
    public class TextFileSharedFormKeyAllocator_Tests : ISharedFormKeyAllocator_Tests<TextFileSharedFormKeyAllocator>
    {
        private const string DefaultName = "default";

        protected override TextFileSharedFormKeyAllocator CreateAllocator(IMod mod, string path) => new(mod, path, DefaultName, preload: true);

        protected override TextFileSharedFormKeyAllocator CreateNamedAllocator(IMod mod, string path, string patcherName) => new(mod, path, patcherName, preload: true);

        protected override string ConstructTypicalPath()
        {
            var path = tempFolder.Value.Dir.Path;
            File.WriteAllText(Path.Combine(path, TextFileSharedFormKeyAllocator.MarkerFileName), null);
            return path;
        }

        [Fact]
        public void StaticExport()
        {
            using var file = tempFile.Value;
            TextFileSharedFormKeyAllocator.WriteToFile(
                file.File.Path,
                new (string, FormKey)[]
                {
                    (Utility.Edid1, Utility.Form1),
                    (Utility.Edid2, Utility.Form2),
                });
            var lines = File.ReadAllLines(file.File.Path + ".txt");
            Assert.Equal(
                new string[]
                {
                    Utility.Edid1,
                    Utility.Form1.ID.ToString(),
                    Utility.Edid2,
                    Utility.Form2.ID.ToString(),
                },
                lines);
        }

        [Fact]
        public void TypicalImport()
        {
            using var folder = tempFolder.Value;

            File.WriteAllLines(
                Path.Combine(folder.Dir.Path, Patcher1 + ".txt"),
                new string[]
                {
                    Utility.Edid1,
                    Utility.Form1.ID.ToString(),
                    Utility.Edid2,
                    Utility.Form2.ID.ToString(),
                });
            File.WriteAllText(Path.Combine(folder.Dir.Path, TextFileSharedFormKeyAllocator.MarkerFileName), null);
            var mod = new OblivionMod(Utility.PluginModKey);
            var allocator = new TextFileSharedFormKeyAllocator(mod, folder.Dir.Path, Patcher1, preload: true);
            var formID = allocator.GetNextFormKey(Utility.Edid1);
            Assert.Equal(Utility.PluginModKey, formID.ModKey);
            Assert.Equal(Utility.Form1, formID);
            formID = allocator.GetNextFormKey(Utility.Edid2);
            Assert.Equal(Utility.Form2, formID);
        }

        [Fact]
        public void FailedImportTruncatedFile()
        {
            using var folder = tempFolder.Value;
            File.WriteAllLines(
                Path.Combine(folder.Dir.Path, Patcher1 + ".txt"),
                new string[]
                {
                    Utility.Edid1,
                    Utility.Form1.ID.ToString(),
                    Utility.Edid2,
                    //Utility.Form2.ID.ToString(),
                });
            var mod = new OblivionMod(Utility.PluginModKey);
            Assert.ThrowsAny<Exception>(() => new TextFileSharedFormKeyAllocator(mod, folder.Dir.Path, DefaultName, preload: true));
        }

        [Fact]
        public void FailedImportDuplicateFormKey()
        {
            using var folder = tempFolder.Value;
            File.WriteAllText(Path.Combine(folder.Dir.Path, TextFileSharedFormKeyAllocator.MarkerFileName), null);
            File.WriteAllLines(
                Path.Combine(folder.Dir.Path, Patcher1 + ".txt"),
                new string[]
                {
                    Utility.Edid1,
                    Utility.Form1.ID.ToString(),
                    Utility.Edid2,
                    Utility.Form1.ID.ToString(),
                });
            var mod = new OblivionMod(Utility.PluginModKey);
            Assert.Throws<ArgumentException>(() => new TextFileSharedFormKeyAllocator(mod, folder.Dir.Path, DefaultName, preload: true));
        }

        [Fact]
        public void FailedImportDuplicateEditorID()
        {
            using var folder = tempFolder.Value;
            File.WriteAllText(Path.Combine(folder.Dir.Path, TextFileSharedFormKeyAllocator.MarkerFileName), null);
            File.WriteAllLines(
                Path.Combine(folder.Dir.Path, Patcher1 + ".txt"),
                new string[]
                {
                    Utility.Edid1,
                    Utility.Form1.ID.ToString(),
                    Utility.Edid1,
                    Utility.Form2.ID.ToString(),
                });
            var mod = new OblivionMod(Utility.PluginModKey);
            Assert.Throws<ArgumentException>(() => new TextFileSharedFormKeyAllocator(mod, folder.Dir.Path, Patcher1, preload: true));
        }

        [Fact]
        public void TypicalReimport()
        {
            using var folder = tempFolder.Value;

            TextFileSharedFormKeyAllocator.WriteToFile(
                Path.Combine(folder.Dir.Path, Patcher1),
                new (string, FormKey)[]
                {
                    (Utility.Edid1, Utility.Form1),
                    (Utility.Edid2, Utility.Form2),
                });
            File.WriteAllText(Path.Combine(folder.Dir.Path, TextFileSharedFormKeyAllocator.MarkerFileName), null);
            var mod = new OblivionMod(Utility.PluginModKey);
            using var allocator = new TextFileSharedFormKeyAllocator(mod, folder.Dir.Path, Patcher1);
            var formID = allocator.GetNextFormKey();
            Assert.Equal(Utility.PluginModKey, formID.ModKey);
            formID = allocator.GetNextFormKey(Utility.Edid1);
            Assert.Equal(formID, Utility.Form1);
            formID = allocator.GetNextFormKey(Utility.Edid2);
            Assert.Equal(formID, Utility.Form2);
        }
    }
}
