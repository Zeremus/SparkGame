using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame(PlayerScript player)
    {
        // Create a path to save the game data
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.joao";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadGame()
    {
        string path = Application.persistentDataPath + "/player.joao";
        if(File.Exists(path))
        {
            // In case of existing saved data, load it
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/player.joao";
        if(File.Exists(path))
        {
            File.Delete(Application.persistentDataPath + "/player.joao");
        }
    }
}
