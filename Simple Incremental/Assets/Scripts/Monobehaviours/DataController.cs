using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/* DataController is responsible for saving and loading persistant data
 * to files in JSON format */

public class DataController : MonoBehaviour
{
    public static DataController instance;
    public GameObject player;
    public GameData gameData = new GameData();
    private string gameDataFileName = "data.json";
    private CharacterLevel characterLevel;
   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameData = new GameData();
            characterLevel = player.GetComponent<CharacterLevel>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(dataAsJson);
            restoreGameState();
        }
        else
        {
            Debug.Log("Creating new json file");
            gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        updateGamedata();
        string dataAsJson = JsonUtility.ToJson(gameData);
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);
        File.WriteAllText(filePath, dataAsJson);
    }

    public void updateGamedata()
    {
        
        gameData.level = characterLevel.level;
    }

    public void restoreGameState()
    {
        characterLevel.level = gameData.level;
    }

}

[System.Serializable]
public class GameData
{
    public ItemInstance[] items;
    public int level;
}

