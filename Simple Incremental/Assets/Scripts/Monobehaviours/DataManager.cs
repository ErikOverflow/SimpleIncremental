using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

/* DataController is responsible for saving and loading persistant data
 * to files in JSON format */

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public GameObject player;
    public GameData gameData = new GameData();
    [SerializeField]
    string gameDataFileName = "data.json";
    CharacterLevel characterLevel;


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

    private void Start()
    {
        LoadGameData();
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
            gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        UpdateGamedata();
        string dataAsJson = JsonUtility.ToJson(gameData, true);
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);
        File.WriteAllText(filePath, dataAsJson);
    }

    private void UpdateGamedata()
    {

        gameData.level = characterLevel.level;
    }

    private void HookGameData()
    {
        characterLevel.level = gameData.level;
        //PlayerInventory.instance.items = gameData.items;
    }

}

[Serializable]
public class GameData
{
    public int level;
}
