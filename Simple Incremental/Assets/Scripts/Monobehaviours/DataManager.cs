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
    public GameObject player = null;
    public GameData gameData = null;
    public Dictionary<string, Item> itemDict;
    [SerializeField]
    string gameDataFileName = "data.json";
    PlayerLevel playerLevel;
    [SerializeField]
    GameEvent itemsEquipped = null;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            playerLevel = player.GetComponent<PlayerLevel>();
            Item[] allitems = Resources.FindObjectsOfTypeAll<Item>();
            itemDict = new Dictionary<string, Item>();
            foreach (Item item in allitems)
            {
                itemDict.Add(item.name, item);
            }
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        LoadGameData();
    }

    public void LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
            foreach (ItemInstance item in gameData.items)
            {
                itemDict.TryGetValue(item.name, out item.item);
            }
            itemDict.TryGetValue(gameData.weapon?.name, out gameData.weapon.item);
            HookGameData();
        }
        else
        {
            gameData = new GameData();
            HookGameData();
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
        gameData.level = playerLevel.level;
        gameData.items = PlayerInventory.instance.items;
        gameData.weapon = PlayerInventory.instance.weapon;
        if (PlayerInventory.instance.weapon?.item == null)
            gameData.weapon = null;
    }

    private void HookGameData()
    {
        playerLevel.level = gameData.level;
        PlayerInventory.instance.items = gameData.items;
        if (gameData.weapon?.item != null)
            PlayerInventory.instance.weapon = gameData.weapon;
    }

}
[Serializable]
public class GameData
{
    public int level = 1;
    public List<ItemInstance> items = new List<ItemInstance>();
    public ItemInstance weapon = null;
}