using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/* DataController is responsible for saving and loading persistant data
 * to files in JSON format */

public class DataController : MonoBehaviour
{
    public static DataController instance;
    public static GameData gameData = new GameData();
    private static string gameDataFileName = "data.json";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameData = new GameData();
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameData.coins = 8;
        SaveGameData();
        LoadGameData();
    }

    public static void LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(dataAsJson);
        }
        else
        {
            Debug.Log("Creating new json file");
            gameData = new GameData();
        }
    }

    public static void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(gameData);
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);
        File.WriteAllText(filePath, dataAsJson);
    }
}

[System.Serializable]
public class GameData
{
    public int coins;
}