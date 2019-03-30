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

    private void Update()
    {
        /* These inputs only in for testing and should be removed before release*/
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGameData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGameData();
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
        gameData.coins = playerAwards.coins;
        gameData.level = characterLevel.level;
    }

    public void restoreGameState()
    {
        playerAwards.coins = gameData.coins;
        characterLevel.level = gameData.level;
    }

}

[System.Serializable]
public class GameData
{
    public int coins;
    public int level;
}

