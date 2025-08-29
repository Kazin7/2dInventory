using UnityEngine;

public enum ItemType { Weapon, Armor, Accessory }

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
//SriptableObject아이템 정보
public class ItemData : ScriptableObject
{
    [Header("기본 정보")]
    public string itemName;
    public Sprite icon;
    public ItemType type;
    public int count = 1;

    [Header("스탯 보너스")]
    public int attackBonus;
    public int shieldBonus;
    public int healthBonus;
    
    public bool IsEquippable => type == ItemType.Weapon || type == ItemType.Armor || type == ItemType.Accessory;
}
