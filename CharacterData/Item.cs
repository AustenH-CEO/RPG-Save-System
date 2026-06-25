using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Save_System.CharacterData
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DamageValue { get; set; }
        public int HPRestoreValue { get; set; }
        public int ManaRestoreValue { get; set; }
        public int ArmorValue {  get; set; }
        public Item (string name, string description)
        {
            Name = name;
            Description = description;
            DamageValue = 0;
            HPRestoreValue = 0;
            ManaRestoreValue = 0;
            ArmorValue = 0;
        }
        public Item (string name, string description, int damageValue, int hpRestoreValue, int manaRestoreValue, int armorValue)
        {
            Name = name;
            Description= description;
            DamageValue = damageValue;
            HPRestoreValue = hpRestoreValue;
            ManaRestoreValue = manaRestoreValue;
            ArmorValue = armorValue;
        }
        public void PrintItemStat()
        {

        }
    }
}

