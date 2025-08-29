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

    public List<ItemData> Inventory { get; private set; } = new();
    ItemData equippedWeapon;
    List<ItemData> equippedArmors = new();
    ItemData equippedAccessory;
    //플레이어 모든 값들을 설정
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
    //아이템을 추가하는 함수
    public void AddItem(ItemData item, int count = 1)
    {
        if (item == null || count <= 0) return;

        var exist = Inventory.Find(x => x.name == item.name);
        if (exist != null)
        {
            exist.count += count;
            return;
        }

        item.count = Mathf.Max(1, item.count > 0 ? item.count : count);
        Inventory.Add(item);
    }
    //아이템 장착 함수 무기,악세서리 1개만 장착 가능 방어구는 여러개
    public bool Equip(ItemData item)
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
    //아이템 해제 함수
    public bool UnEquip(ItemData item)
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
    //아이템 보너스 스탯 처리하는 함수 sign이 +1이면 장착 -1이면 해제 설정
    void ApplyBonus(ItemData item, int sign)
    {
        Attack += sign * item.attackBonus;
        Shield += sign * item.shieldBonus;
        Health += sign * item.healthBonus;

        Attack = Mathf.Max(0, Attack);
        Shield = Mathf.Max(0, Shield);
        Health = Mathf.Max(0, Health);
    }
    //장비를 이미 장착하고있는지 확인하는 함수
    public bool IsEquipped(ItemData item)
    {
        if (item == null) return false;
        if (item.type == ItemType.Weapon) return equippedWeapon == item;
        if (item.type == ItemType.Armor) return equippedArmors.Contains(item);
        if (item.type == ItemType.Accessory) return equippedAccessory == item;
        return false;
    }
}
