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
            HookGameData();
        }
        else
        {
            Debug.Log("Creating new json file");
            gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        UpdateGamedata();
        string dataAsJson = JsonUtility.ToJson(gameData);
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);
        File.WriteAllText(filePath, dataAsJson);
    }

    private void UpdateGamedata()
    {
        
        gameData.level = characterLevel.level;
        gameData.items = PlayerInventory.instance.items;
    }

    private void HookGameData()
    {
        characterLevel.level = gameData.level;
        PlayerInventory.instance.items = gameData.items;
    }

}

[System.Serializable]
public class GameData
{
    public List<ItemInstance> items;
    public int level;
}

