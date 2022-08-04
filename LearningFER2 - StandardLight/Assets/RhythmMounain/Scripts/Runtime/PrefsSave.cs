using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class PrefsSave 
{
    public static void SaveGame (ScoringSystem ssdata)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scoreData.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(ssdata);     
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadData ()
    {
        string path = Application.persistentDataPath + "/scoreData.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream(path, FileMode.Open);

           GameData data = formatter.Deserialize(stream) as GameData;
           stream.Close();
           return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
