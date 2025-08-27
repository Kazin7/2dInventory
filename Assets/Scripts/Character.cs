using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name { get; private set; } = "Chad";
    public int Level { get; private set; } = 10;
    public int Exp { get; private set; } = 9;
    public int MaxExp;
    public int Attack { get; private set; } = 35;
    public int Shield { get; private set; } = 40;
    public int Health { get; private set; } = 100;
    public int Critical { get; private set; } = 25;

    public List<Item> Inventory { get; private set; } = new();
    Item equippedWeapon;
    List<Item> equippedArmors = new();
    Item equippedAccessory;

    public void SetUp(
        string name = null,
        int? level = null,
        int? exp = null,
        int? attack = null,
        int? shield = null,
        int? health = null,
        int? critical = null)
    {
        if (name != null) Name = name;
        if (level != null) Level = level.Value;
        if (exp != null) Exp = exp.Value;
        if (attack != null) Attack = attack.Value;
        if (shield != null) Shield = shield.Value;
        if (health != null) Health = health.Value;
        if (critical != null) Critical = critical.Value;

        MaxExp = Level * 3;
    }

    public void AddItem(Item item, int count = 1)
    {
        if (item == null || count <= 0) return;

        var exist = Inventory.Find(x => x.id == item.id);
        if (exist != null)
        {
            exist.count += count;
            return;
        }

        item.count = Mathf.Max(1, item.count > 0 ? item.count : count);
        Inventory.Add(item);
    }
    public void Additem(Item item, int count = 1) => AddItem(item, count);

    public bool Equip(Item item)
    {
        if (item == null || !item.IsEquippable) return false;
        if (!Inventory.Contains(item)) return false;

        switch (item.type)
        {
            case ItemType.Weapon:
                if (equippedWeapon != null) UnEquip(equippedWeapon);
                equippedWeapon = item;
                ApplyBonus(item, +1);
                return true;

            case ItemType.Armor:
                if (!equippedArmors.Contains(item))
                {
                    equippedArmors.Add(item);
                    ApplyBonus(item, +1);
                    return true;
                }
                return false;

            case ItemType.Accessory:
                if (equippedAccessory != null) UnEquip(equippedAccessory);
                equippedAccessory = item;
                ApplyBonus(item, +1);
                return true;

            default:
                return false;
        }
    }

    public bool UnEquip(Item item)
    {
        if (item == null) return false;

        if (item.type == ItemType.Weapon && equippedWeapon == item)
        {
            ApplyBonus(equippedWeapon, -1);
            equippedWeapon = null;
            return true;
        }
        if (item.type == ItemType.Armor && equippedArmors.Contains(item))
        {
            equippedArmors.Remove(item);
            ApplyBonus(item, -1);
            return true;
        }
        if (item.type == ItemType.Accessory && equippedAccessory == item)
        {
            ApplyBonus(equippedAccessory, -1);
            equippedAccessory = null;
            return true;
        }
        return false;
    }

    void ApplyBonus(Item item, int sign)
    {
        Attack += sign * item.attackBonus;
        Shield += sign * item.shieldBonus;
        Health += sign * item.healthBonus;

        Attack = Mathf.Max(0, Attack);
        Shield = Mathf.Max(0, Shield);
        Health = Mathf.Max(0, Health);
    }
    public bool IsEquipped(Item item)
    {
        if (item == null) return false;
        if (item.type == ItemType.Weapon) return equippedWeapon == item;
        if (item.type == ItemType.Armor) return equippedArmors.Contains(item);
        if (item.type == ItemType.Accessory) return equippedAccessory == item;
        return false;
    }
}
