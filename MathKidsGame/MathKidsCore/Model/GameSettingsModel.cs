using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace MathKidsCore.Model
{
    [Serializable]
    public class GameSettingsModel
    {
        public string CurrentUserName { get; set; } = "User Name";
        public int MaxResult { get; set; }
        public GameDificulty Dificulty { get; set; }
        public IEnumerable<MathOperations> Operations { get; set; } = new List<MathOperations>() { MathOperations.Add };

        public static void Save(GameSettingsModel settings)
        {
            try
            {
                IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("SuperAccountant.txt", FileMode.Create, f))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(stream, settings);
                    writer.Flush();
                }
            }
            catch { }
        }

        public static void Load(GameSettingsModel gameSettings)
        {
            GameSettingsModel loadedSettings = new GameSettingsModel();

            try
            {
                IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("SuperAccountant.txt", FileMode.OpenOrCreate, f)) 
                {
                    BinaryFormatter b = new BinaryFormatter();
                    loadedSettings = (GameSettingsModel)b.Deserialize(stream);
                }
            }
            catch(Exception ex)
            { }

            foreach (PropertyInfo property in typeof(GameSettingsModel).GetProperties().Where(p => p.CanWrite))
            {
                property.SetValue(gameSettings, property.GetValue(loadedSettings, null), null);
            }
        }
    }
}
