using RPG_Save_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RPG_Save_System.CharacterData
{
    public class Item: ISaveable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    name = "Pocket Lint";
                else
                    name = value;
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value == null)
                    description = "Pocket lint... nothing of value.";
                else
                    description = value;
            }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    quantity = 0;
                else
                    quantity = value;
            }
        }
        public int DamageValue { get; set; }
        public int HPRestoreValue { get; set; }
        public Item (string name, string description)
        {
            Name = name;
            Description = description;
            Quantity = 0;
            DamageValue = 0;
            HPRestoreValue = 0;
        }
        public Item (string name, string description, int quantity ,int damageValue, int hpRestoreValue)
        {
            Name = name;
            Description= description;
            Quantity= quantity;
            DamageValue = damageValue;
            HPRestoreValue = hpRestoreValue;
        }
        public void PrintItem()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            if (Quantity > 0)
            {
                Console.WriteLine($"Amount: {Quantity}");
            }
            if (DamageValue > 0)
            {
                Console.WriteLine($"Damage Value: {DamageValue}");
            }
            if (HPRestoreValue > 0)
            {
                Console.WriteLine($"HP Restore Value: {HPRestoreValue}");
            }
        }
        public string ToJson()
        { 
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            return json;
        }
    }
}

