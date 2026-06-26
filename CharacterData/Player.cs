using RPG_Save_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json;

namespace RPG_Save_System.CharacterData
{
    public class Player: IGameCharacter, ISaveable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    name = "John Doe";
                else
                    name = value;
            }
        }
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
        private List<Item> items = new List<Item>();
        public Player (string name, int health, int level)
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
            foreach (var item in items)
            {
                if (item == null)
                    Console.WriteLine("No Items");
                else
                {
                    Console.WriteLine("Item: " + item.Name);
                    Console.WriteLine("Description: " + item.Description);
                    Console.WriteLine("Count: " + item.Quantity);
                }
            }
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (health <= 0)
            {
                Console.WriteLine(this.Name + " took " + amount + " damage.");
                Console.WriteLine(this.Name + " died.");
            }
            else
                Console.WriteLine(this.Name + " took " + amount + " damage.");
        }
        public void LevelUp()
        {
            Level += 1;
            Console.WriteLine(this.Name + " leveled up! " + "(" + this.Level + ")");
        }
        public string ToJson()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            return json;
        }

    }
}
