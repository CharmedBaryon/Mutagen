using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Oblivion
{
    public static class GlobalGroupMixIn
    {
        public static GlobalFloat AddNewFloat(this IGroupCommon<Global> globals)
        {
            var ret = new GlobalFloat(
                globals.SourceMod.GetNextFormKey());
            globals.Add(ret);
            return ret;
        }

        public static GlobalFloat AddNewFloat(this IGroupCommon<Global> globals, string editorId)
        {
            var ret = new GlobalFloat(
                globals.SourceMod.GetNextFormKey(editorId));
            globals.Add(ret);
            return ret;
        }

        public static GlobalInt AddNewInt(this IGroupCommon<Global> globals)
        {
            var ret = new GlobalInt(
                globals.SourceMod.GetNextFormKey());
            globals.Add(ret);
            return ret;
        }

        public static GlobalInt AddNewInt(this IGroupCommon<Global> globals, string editorId)
        {
            var ret = new GlobalInt(
                globals.SourceMod.GetNextFormKey(editorId));
            globals.Add(ret);
            return ret;
        }

        public static GlobalShort AddNewShort(this IGroupCommon<Global> globals)
        {
            var ret = new GlobalShort(
                globals.SourceMod.GetNextFormKey());
            globals.Add(ret);
            return ret;
        }

        public static GlobalShort AddNewShort(this IGroupCommon<Global> globals, string editorId)
        {
            var ret = new GlobalShort(
                globals.SourceMod.GetNextFormKey(editorId));
            globals.Add(ret);
            return ret;
        }
    }
}
