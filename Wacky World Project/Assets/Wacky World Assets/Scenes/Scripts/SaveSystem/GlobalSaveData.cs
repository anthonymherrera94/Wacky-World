using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Reflection;
using System;

namespace SaveSystem
{
    public static class GlobalSaveData
    {
        private static GameData[] games = new GameData[3];
   
        static GlobalSaveData()
        {
            Load();
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }
        private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            return typeof(GlobalSaveData).Assembly;
        }
        public static void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/Save.bin",FileMode.Create);
            bf.Serialize(fs, games);
            fs.Close();
        
        }

        public static void Load()
        {
            Debug.Log(Application.persistentDataPath + "/Save.bin");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/Save.bin", FileMode.OpenOrCreate);
            fs.Position = 0;
            if (fs.Length == 0)
                games = new GameData[3];
            else
            {
                Debug.Log(fs.Length);
                System.Object obj = bf.Deserialize(fs);
                GameData[] lod = obj as GameData[];
                for (int i = 0; i < lod.Length; i++)
                    games[i] = lod[i];
            }
            fs.Close();
        }

        public static void AddGame(int index, string name)
        {
            games[index] = new GameData(name);
            Save();
        }

        public static GameData GetSave(int index)
        {
            return games[index];
        }
    }
}
