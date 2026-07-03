using RPG_Save_System.CharacterData;
using RPG_Save_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RPG_Save_System.SaveData
{
    public static class SaveManager
    {
        public static void Save(ISaveable entity)
        {
            string folder = @"C:\Users\austen.hernandez\source\repos\AustenH-CEO\RPG-Save-System\SaveData\";
            string file = "Saves.json";
            string fullPath = Path.Combine(folder, file);
            File.WriteAllText(fullPath, entity.ToJson());
            Console.WriteLine("Player Saved.");
        }
        public static T Load<T>(string path)
        {
            if (File.Exists(path))
            {
                string jsonText = File.ReadAllText(path);
                ISaveable loadSave = (ISaveable)JsonSerializer.Deserialize<T>(jsonText);
                Console.WriteLine("Player Loaded.");
                return (T)loadSave;
            }
            else
                return default(T);
        }

    }
}
