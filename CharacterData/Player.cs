using RPG_Save_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;

namespace RPG_Save_System.CharacterData
{
    public class Player: IGameCharacter, ISaveable
    {
        private string name;
        public string Name { get; set; }
        private int health;
        public int Health
        {
            get {  return health; }
            set
            {
                if (value < 0)
                    health = 0;
                else
                    health = value;
            }
        }
        public int Level { get; set; }
        public bool IsAlive { get; set; } = true;
        private List<Item> items = new List<Item>();
        public List<Item> Items { get => items; set => items = value; }
        public Player(string name, int health, int level)
        {
            Name = name;
            Health = health;
            Level = level;
        }
        public void DisplayPlayer()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Level: " + Level);
        }
        public void DisplayInventory()
        {
            Console.WriteLine("");
            Console.WriteLine("--------Inventory--------");
            if (Items.Count == 0)
            {
                Console.WriteLine("No Items.");
                return;
            }
            else
            {
                foreach (var item in Items)
                {
                        item.PrintItem();
                }
            }
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (health <= 0)
            {
                Console.WriteLine(Name + " took " + amount + " damage.");
                Console.WriteLine(Name + " died.");
                IsAlive = false;
            }
            else
                Console.WriteLine(Name + " took " + amount + " damage.");
        }
        public void LevelUp()
        {
            if (IsAlive)
            {
                Level += 1;
                Console.WriteLine(Name + " leveled up! " + "(" + Level + ")");
            }
            else
                Console.WriteLine("Can't Level Up.");
        }
        public string ToJson()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            return json;
        }

    }
}
