using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIInventory : MonoBehaviour
{
    public Button backBtn;
    [SerializeField] public GameObject uiInventory;
    [SerializeField] UISlot slotPrefab;
    [SerializeField] Transform slotParent;
    [SerializeField] int initialCount = 12;

    public List<UISlot> slots = new();

    void Start()
    {
        if (UIManager.Instance.uiInventory == null)
            UIManager.Instance.uiInventory = this;
        if (uiInventory == null)
            uiInventory = this.gameObject;

        if (backBtn) backBtn.onClick.AddListener(OnclickBack);
        UIManager.Instance?.MakeTooltip();
        if (!slotParent)
        {
            var sr = GetComponentInChildren<ScrollRect>(true);
            if (sr) slotParent = sr.content;
        }

        InitInventoryUI();

        var gm = GameManager.Instance;
        if (gm != null && gm.player != null)
            RefreshFrom(gm.player);
    }

    public void OnclickBack() => uiInventory.SetActive(false);

    public void InitInventoryUI()
    {
        if (!slotPrefab || !slotParent) return;

        for (int i = slotParent.childCount - 1; i >= 0; i--)
            Destroy(slotParent.GetChild(i).gameObject);

        slots.Clear();

        for (int i = 0; i < initialCount; i++)
        {
            var slot = Instantiate(slotPrefab, slotParent);
            slot.Clear();
            slots.Add(slot);
        }
    }

    public void RefreshFrom(Character c)
    {
        if (c == null || slots == null) return;

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < c.Inventory.Count && c.Inventory[i] != null)
            {
                var item = c.Inventory[i];
                var slot = slots[i];

                slot.SetItem(item.icon);
                slot.BindItem(item);

                var btn = slot.GetComponentInChildren<Button>(true);
                if (btn)
                {
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(() => OnSlotClicked(c, item, slot));
                }

                slot.SetEquipped(c.IsEquipped(item));
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    void OnSlotClicked(Character c, Item item, UISlot slot)
    {
        if (item == null || !item.IsEquippable) return;

        if (c.IsEquipped(item)) c.UnEquip(item);
        else                    c.Equip(item);

        RefreshFrom(c);
    }

}
