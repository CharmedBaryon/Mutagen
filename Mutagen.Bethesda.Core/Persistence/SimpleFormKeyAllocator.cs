 using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Persistence
{
    /// <summary> 
    /// A simple FormKey allocator that simply leverages a Mod's NextObjectID tracker to allocate. 
    /// No safety checks or syncronization is provided. 
    /// 
    /// This class is thread safe. 
    /// </summary> 
    public class SimpleFormKeyAllocator : IFormKeyAllocator
    {
        /// <summary> 
        /// Attached Mod that will be used as reference when allocating new keys 
        /// </summary> 
        public IMod Mod { get; }

        /// <summary> 
        /// Constructs a new SimpleNextIDAllocator that looks to a given Mod for the next key 
        /// </summary> 
        public SimpleFormKeyAllocator(IMod mod)
        {
            this.Mod = mod;
        }

        /// <summary> 
        /// Returns a FormKey with the next listed ID in the Mod's header. 
        /// No checks will be done that this is truly a unique key; It is assumed the header is in a correct state. 
        /// 
        /// The Mod's header will be incremented to mark the allocated key as "used". 
        /// </summary> 
        /// <returns>The next FormKey from the Mod</returns> 
        public FormKey GetNextFormKey()
        {
            lock (this.Mod)
            {
                return new FormKey(
                    this.Mod.ModKey,
                    checked(this.Mod.NextFormID++));
            }
        }

        public FormKey GetNextFormKey(string? editorID)
        {
            return GetNextFormKey();
        }
    }
}
