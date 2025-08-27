using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character player;

    [Header("Item Icons (0:sword, 1:shield, 2:armor)")]
    [SerializeField] List<Sprite> itemIcons;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        if (!player) player = FindObjectOfType<Character>();
        SetData();
    }

    public void SetData()
    {
        if (!player) return;

        player.SetUp("김영식");

        var sword  = new Item("sword",  GetIcon(0), ItemType.Weapon,     1, attackBonus: 10);
        var shield = new Item("shield", GetIcon(1), ItemType.Armor,      1, shieldBonus: 8);
        var potion = new Item("armor",GetIcon(2), ItemType.Armor, 1 , shieldBonus: 20);

        player.AddItem(sword);
        player.AddItem(shield);
        player.AddItem(potion);
    }

    Sprite GetIcon(int index)
    {
        if (itemIcons != null && index >= 0 && index < itemIcons.Count)
            return itemIcons[index];
        return null;
    }
}
