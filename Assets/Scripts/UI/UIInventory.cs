using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIInventory : MonoBehaviour
{
    public Button backBtn;
    [SerializeField] public GameObject uiInventory;
    [SerializeField] UISlot slotPrefab;
    [SerializeField] Transform slotParent;
    [SerializeField] int initialCount = 12; //시작 갯수

    public List<UISlot> slots = new(); //현재 플레이어가 가지고있는 아이템 슬롯수

    void Start()
    {
        //예외처리
        if (UIManager.Instance.uiInventory == null)
            UIManager.Instance.uiInventory = this;
        if (uiInventory == null)
            uiInventory = this.gameObject;

        //뒤로가기
        if (backBtn) backBtn.onClick.AddListener(OnclickBack);

        UIManager.Instance?.MakeTooltip();

        //인벤토리 아이템 슬롯을 담을 부모(content)로 지정.
        if (!slotParent)
        {
            var sr = GetComponentInChildren<ScrollRect>(true);
            if (sr) slotParent = sr.content;
        }

        InitInventoryUI();

        //플레이어 정보를 가져와서 UI에 반영
        var gm = GameManager.Instance;
        if (gm != null && gm.player != null)
            RefreshForm(gm.player);
    }
    //뒤로가기 버튼 클릭시 창닫음
    public void OnclickBack()
    {
        uiInventory.SetActive(false);
    }
    //인벤토리 UI 초기화
    public void InitInventoryUI()
    {
        if (!slotPrefab || !slotParent) return;

        //모든 슬롯 제거
        for (int i = slotParent.childCount - 1; i >= 0; i--)
            Destroy(slotParent.GetChild(i).gameObject);

        slots.Clear();

        //다시 생성
        for (int i = 0; i < initialCount; i++)
        {
            var slot = Instantiate(slotPrefab, slotParent);
            slot.Clear();
            slots.Add(slot);
        }
    }
    //
    public void RefreshForm(Character c)
    {
        if (c == null || slots == null) return;

        for (int i = 0; i < slots.Count; i++)
        {
            //캐릭터 인벤토리 개수보다 작고, 아이템이 있으면 표시
            if (i < c.Inventory.Count && c.Inventory[i] != null)
            {
                var item = c.Inventory[i];
                var slot = slots[i];

                slot.SetItem(item.icon);
                slot.BindItem(item);
                //슬롯 안의 버튼을 찾아서 기존이벤트 제거후 이벤트 등록
                var btn = slot.GetComponentInChildren<Button>(true);
                if (btn)
                {
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(() => OnSlotClicked(c, item, slot));
                }
                //슬롯 장착 표시
                slot.SetEquipped(c.IsEquipped(item));
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
    //슬롯 클릭 시 장착/해제 처리    
    void OnSlotClicked(Character c, ItemData item, UISlot slot)
    {
        if (item == null || !item.IsEquippable) return;

        if (c.IsEquipped(item)) c.UnEquip(item);
        else                    c.Equip(item);

        RefreshForm(c);
    }

}
