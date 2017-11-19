using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaltConsola
{
    public class Item
    {
        public enum ItemType { WEAPON, ARMOR, USABLE, BATTLE_ITEM, NON_USABLE };
        public enum ItemTarget { STRENGTH, LIFE, SKILL, INTELLIGENCE, ATTACK, DEFENSE, CONSTITUTION}

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type {get;set;}
        public ItemTarget[] Target { get; set; }
        public int[] Bonus { get; set; }

    }
}
