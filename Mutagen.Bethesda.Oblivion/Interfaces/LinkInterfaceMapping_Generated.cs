/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections.Generic;
using Mutagen.Bethesda.Core;

namespace Mutagen.Bethesda.Oblivion.Internals
{
    public class LinkInterfaceMapping : ILinkInterfaceMapping
    {
        public IReadOnlyDictionary<Type, Type[]> InterfaceToObjectTypes { get; }

        public GameCategory GameCategory => GameCategory.Oblivion;

        public LinkInterfaceMapping()
        {
            var dict = new Dictionary<Type, Type[]>();
            dict[typeof(IItem)] = new Type[]
            {
                typeof(AlchemicalApparatus),
                typeof(Ammunition),
                typeof(Armor),
                typeof(Book),
                typeof(Clothing),
                typeof(Ingredient),
                typeof(Key),
                typeof(LeveledItem),
                typeof(Light),
                typeof(Miscellaneous),
                typeof(Potion),
                typeof(SigilStone),
                typeof(SoulGem),
                typeof(Weapon),
            };
            dict[typeof(IItemGetter)] = dict[typeof(IItem)];
            dict[typeof(INpcSpawn)] = new Type[]
            {
                typeof(Creature),
                typeof(LeveledCreature),
                typeof(Npc),
            };
            dict[typeof(INpcSpawnGetter)] = dict[typeof(INpcSpawn)];
            dict[typeof(INpcRecord)] = new Type[]
            {
                typeof(Creature),
                typeof(Npc),
            };
            dict[typeof(INpcRecordGetter)] = dict[typeof(INpcRecord)];
            dict[typeof(IOwner)] = new Type[]
            {
                typeof(Faction),
                typeof(Npc),
            };
            dict[typeof(IOwnerGetter)] = dict[typeof(IOwner)];
            dict[typeof(IPlaced)] = new Type[]
            {
                typeof(Landscape),
                typeof(PlacedCreature),
                typeof(PlacedNpc),
                typeof(PlacedObject),
            };
            dict[typeof(IPlacedGetter)] = dict[typeof(IPlaced)];
            dict[typeof(ISpellRecord)] = new Type[]
            {
                typeof(LeveledSpell),
                typeof(Spell),
            };
            dict[typeof(ISpellRecordGetter)] = dict[typeof(ISpellRecord)];
            InterfaceToObjectTypes = dict;
        }
    }
}

