//This program will demonstrate saving your character in an RPG
// Austen Hernandez
// 6.24.26
using RPG_Save_System.CharacterData;
using RPG_Save_System.SaveData;
using RPG_Save_System.Interfaces;
using System.Collections.Specialized;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;
public class Program
{
    public static void Main()
    {
        bool exitMenu = false;
        do
        {
            Console.WriteLine("--------------");
            Console.WriteLine("(1) New Player");
            Console.WriteLine("(2) Load Player");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("--------------");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                switch (value)
                {
                    case 1:
                        Console.WriteLine("Enter Name: ");
                        string name = ValidLetter();
                        Player player = new Player(name, 100, 1);
                        player.AddItem(new Item("Health Potion", "Heals character.", 3, 0, 50));
                        player.AddItem(new Item("LongSword", "Stab and slash.", 1, 100, 0));
                        SaveManager.Save(player);
                        player.DisplayPlayer();
                        player.DisplayInventory();

                        break;
                    case 2:
                        string path = @"C:\Users\austen.hernandez\source\repos\AustenH-CEO\RPG-Save-System\SaveData\Saves.json";
                        Player loadedPlayer = SaveManager.Load<Player>(path);
                        loadedPlayer.DisplayPlayer();
                        loadedPlayer.DisplayInventory();
                        loadedPlayer.TakeDamage(30);
                        loadedPlayer.LevelUp();
                        SaveManager.Save(loadedPlayer);
                        break;
                    case 3:
                        exitMenu = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        } while (exitMenu == false);
    }
    public static string ValidLetter()
    {
        string input;
        bool isValid = false;
        do
        {
            input = Console.ReadLine();
            int charactersCount = input.Length;
            int validCharacters = 0;
            foreach (char character in input)
            {
                if (!char.IsLetter(character) && character != ' ')
                {
                    Console.WriteLine("Invalid Character");
                    break;
                }
                else
                    ++validCharacters;
            }
            if(validCharacters == charactersCount)
            {
                isValid = true;
            }
        } while (isValid == false);
        return input;
    }
}