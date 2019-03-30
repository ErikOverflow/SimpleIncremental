[System.Serializable]
public class Equipment : Item
{
    public int level;
    public int experience;

    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(ScriptableInstantiate(this));
    }
}