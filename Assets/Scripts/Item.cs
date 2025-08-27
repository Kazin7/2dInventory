using UnityEngine;

public enum ItemType { Consumable, Weapon, Armor, Accessory, Material }

[System.Serializable]
public class Item
{
    public string id;
    public Sprite icon;
    public ItemType type;
    public int count;

    public int attackBonus;
    public int shieldBonus;
    public int healthBonus;

    public bool IsEmpty => (icon == null && string.IsNullOrEmpty(id)) || count <= 0;
    public bool IsEquippable => type == ItemType.Weapon || type == ItemType.Armor || type == ItemType.Accessory;

    public Item(
        string id,
        Sprite icon,
        ItemType type,
        int count = 1,
        int attackBonus = 0,
        int shieldBonus = 0,
        int healthBonus = 0)
    {
        this.id = id;
        this.icon = icon;
        this.type = type;
        this.count = Mathf.Max(1, count);
        this.attackBonus = attackBonus;
        this.shieldBonus = shieldBonus;
        this.healthBonus = healthBonus;
    }
}
