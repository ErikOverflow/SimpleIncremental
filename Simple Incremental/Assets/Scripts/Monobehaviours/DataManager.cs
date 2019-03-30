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
    public GameData gameData = null;
    [SerializeField]
    string gameDataFileName = "data.json";
    CharacterLevel characterLevel;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson(json, typeof(GameData)) as GameData;
            gameData.items = new List<Item>();
            foreach(TypeString its in gameData.itemTypeString)
            {
                Item o = (Item)Activator.CreateInstance(Type.GetType(its.type));
                JsonUtility.FromJsonOverwrite(its.itemString, o);
                gameData.items.Add(o);
            }
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
        gameData.itemTypeString = new List<TypeString>();
        foreach(Item i in PlayerInventory.instance.items)
        {
            gameData.itemTypeString.Add(new TypeString { type = i.GetType().ToString(), itemString = i.GetSerialized() });
        }
    }

    private void HookGameData()
    {
        characterLevel.level = gameData.level;
        PlayerInventory.instance.items = gameData.items;
    }

}
[Serializable]
public class GameData
{
    public int level;
    public List<TypeString> itemTypeString;
    [NonSerialized]
    public List<Item> items;
}

[Serializable]
public struct TypeString
{
    public string type;
    public string itemString;
}