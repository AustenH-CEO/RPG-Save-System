//This program will demonstrate saving your character in an RPG
// Austen Hernandez
// 6.24.26
using RPG_Save_System.CharacterData;
using RPG_Save_System.SaveData;
using RPG_Save_System.Interfaces;
using System.Collections.Specialized;
using System.Text.Json;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("(1) New Player");
        Console.WriteLine("(2) Load Player");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int value))
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, 100, 1);
                    player.AddItem(new Item("Health Potion", "Heals character.", 3, 0, 50));
                    player.AddItem(new Item("LongSword", "Stab and slash.", 1, 100, 0));
                    SaveManager.Save(player);
                    player.DisplayPlayer();

                    break;
                case 2:
                    string path = @"C:\Users\austen.hernandez\source\repos\RPG-Save-System\SaveData\Saves";
                    Player loadedPlayer = SaveManager.Load<Player>(path);
                    loadedPlayer.DisplayPlayer();
                    loadedPlayer.DisplayInventory();
                    loadedPlayer.TakeDamage(30);
                    loadedPlayer.LevelUp();
                    SaveManager.Save(loadedPlayer);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}