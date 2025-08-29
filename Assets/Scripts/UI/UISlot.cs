using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image icon;
    [SerializeField] Button button;
    [SerializeField] RectTransform equipBadge;

    [SerializeField] Graphic borderTarget;

    Sprite cur;
    ItemData boundItem;

    public bool IsEmpty => cur == null;
    void Awake()
    {
        //인스펙터로 연결안되어있을경우 찾아서 넣음
        if (!button) button = GetComponentInChildren<Button>(true) ?? GetComponent<Button>();
        if (!icon)   icon   = transform.Find("Icon")?.GetComponent<Image>() ?? GetComponent<Image>();
        if (!borderTarget) borderTarget = GetComponent<Image>();
        if (!equipBadge)
        equipBadge = transform.Find("Item/EquipBadge") as RectTransform
                  ?? transform.Find("EquipBadge") as RectTransform;

        //기본적으로는 장착안되어있음
        if (equipBadge) equipBadge.gameObject.SetActive(false);
    }
    public void SetItem(Sprite s)
    {
        cur = s;
        RefreshUI();
    }
    //UI갱신하는 함수    
    public void RefreshUI()
    {
        bool has = cur != null;
        if (icon)
        {
            icon.enabled = has;
            icon.sprite = cur;
            icon.preserveAspect = true;
        }
        if (button) button.interactable = has;
        if (!has) SetEquipped(false);
    }
    //아이콘과 실제 데이터를 연결
    public void BindItem(ItemData item)
    {
        boundItem = item;
    }
    //마우스 포인터에따른 동작 정의
    public void OnPointerEnter(PointerEventData e)
    {
        if (boundItem != null) UIManager.Instance.uiTooltip?.Show(boundItem, e.position);
    }

    public void OnPointerExit(PointerEventData e)
    {
        UIManager.Instance.uiTooltip?.Hide();
    }
    //초기화 함수
    public void Clear()
    {
        boundItem = null;
        UIManager.Instance.uiTooltip?.Hide();
        cur = null;
        RefreshUI();
        SetEquipped(false);
    }
    //장착 표시용
    public void SetEquipped(bool on)
    {
        if (equipBadge) equipBadge.gameObject.SetActive(on);
    }
}
