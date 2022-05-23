using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SaveToFile ()
    {
        (int, bool)[] data = new (int, bool)[2];

        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/playerData.dat";
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        data[0] = (PlayerData.levelOneHighScore, PlayerData.levelOneComplete);
        data[1] = (PlayerData.levelTwoHighScore, PlayerData.levelTwoComplete);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static void LoadFromFile()
    {
        string filePath = Application.persistentDataPath + "/playerData.dat";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            (int, bool)[] data = formatter.Deserialize(fileStream) as (int, bool)[];
            PlayerData.levelOneHighScore = data[0].Item1;
            PlayerData.levelOneComplete = data[0].Item2;
            PlayerData.levelTwoHighScore = data[1].Item1;
            PlayerData.levelTwoComplete = data[1].Item2;

            fileStream.Close();
        }
    }
}
