using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

/* DataController is responsible for saving and loading persistant data
 * to files in JSON format */

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public GameObject player = null;
    public GameData gameData = null;
    public Dictionary<string, Item> itemDict;
    [SerializeField]
    string gameDataFileName = "data.dat";
    PlayerLevel playerLevel;


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
        PlayerInventory.instance.OnInventoryChange += SaveGameData;
    }

    public void LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
            foreach (ItemInstance item in gameData.itemInstance.items)
            {
                itemDict.TryGetValue(item.templateName, out item.item);
            }
            itemDict.TryGetValue(gameData.weapon?.templateName, out gameData.weapon.item);
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
        gameData.itemInstance.items = PlayerInventory.instance.items;
        gameData.weapon = PlayerInventory.instance.weapon;
        if (PlayerInventory.instance.weapon?.item == null)
            gameData.weapon = null;
    }

    private void HookGameData()
    {
        playerLevel.level = gameData.level;
        PlayerInventory.instance.items = gameData.itemInstance.items;
        if (gameData.weapon?.item != null)
            PlayerInventory.instance.weapon = gameData.weapon;
    }

}
[Serializable]
public class GameData
{
    public int level = 1;
    public ItemInstances itemInstance = new ItemInstances();
    public WeaponInstance weapon = null;
}

[Serializable]
public class ItemInstances : ISerializationCallbackReceiver
{
    [NonSerialized]
    public List<ItemInstance> items = new List<ItemInstance>();
    //[SerializeField]
    public List<string> _serializedItems;
    //[SerializeField]
    public List<string> _itemType;

    public void OnBeforeSerialize()
    {
        _serializedItems = new List<string>();
        _itemType = new List<string>();
        for (int i = 0; i < items.Count; i++)
        {
            _serializedItems.Add(JsonUtility.ToJson(items[i]));
            _itemType.Add(items[i].GetType().ToString());
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < _serializedItems.Count; i++)
        {
            Type type = Type.GetType(_itemType[i]);
            items.Add((ItemInstance)JsonUtility.FromJson(_serializedItems[i], type));
        }
    }
}