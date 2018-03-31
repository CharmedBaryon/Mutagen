﻿using Noggog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda
{
    public struct ModKey : IEquatable<ModKey>
    {
        public StringCaseAgnostic Name { get; private set; }
        public bool Master { get; private set; }
        public string FileName => this.ToString();

        public ModKey(
            string name,
            bool master)
        {
            this.Name = name;
            this.Master = master;
        }

        public bool Equals(ModKey other)
        {
            return this.Name.Equals(other.Name)
                && this.Master == other.Master;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ModKey key)) return false;
            return Equals(key);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode()
                .CombineHashCode(Master.GetHashCode());
        }

        public override string ToString()
        {
            return $"{Name}.{(this.Master ? "esm" : "esp")}";
        }

        public static bool TryFactory(string str, out ModKey modKey)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                modKey = default(ModKey);
                return false;
            }
            var split = str.Split('.');
            if (split.Length != 2)
            {
                modKey = default(ModKey);
                return false;
            }
            bool master;
            switch (split[1].ToLower())
            {
                case "esm":
                    master = true;
                    break;
                case "esp":
                    master = false;
                    break;
                default:
                    modKey = default(ModKey);
                    return false;
            }
            modKey = new ModKey(
                name: split[0],
                master: master);
            return true;
        }
    }
}
