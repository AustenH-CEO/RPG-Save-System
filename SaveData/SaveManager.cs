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
            string folder = @"C:\Users\austen.hernandez\source\repos\RPG-Save-System\SaveData";
            string file = "Saves";
            string fullPath = Path.Combine(folder, file);
            File.WriteAllText(fullPath, entity.ToJson());
        }
        public static T Load<T>(string path)
        {
            if (path != null)
            {
                string jsonText = File.ReadAllText(path);
                ISaveable loadSave = (ISaveable)JsonSerializer.Deserialize<T>(jsonText);
                return (T)loadSave;
            }
            return default(T);
        }

    }
}
