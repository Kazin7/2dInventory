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
    Outline outline;
    ItemData boundItem;

    public bool IsEmpty => cur == null;
    void Awake()
    {
        if (!button) button = GetComponentInChildren<Button>(true) ?? GetComponent<Button>();
        if (!icon)   icon   = transform.Find("Icon")?.GetComponent<Image>() ?? GetComponent<Image>();
        if (!borderTarget) borderTarget = GetComponent<Image>();
        if (!equipBadge)
        equipBadge = transform.Find("Item/EquipBadge") as RectTransform
                  ?? transform.Find("EquipBadge") as RectTransform;

        if (equipBadge) equipBadge.gameObject.SetActive(false);

        if (borderTarget)
        {
            outline = borderTarget.GetComponent<Outline>();
            if (!outline) outline = borderTarget.gameObject.AddComponent<Outline>();

            outline.effectColor = Color.red;
            outline.effectDistance = new Vector2(5f, -5f);

            outline.enabled = false;
        }
    }
    public void SetItem(Sprite s)
    {
        cur = s;
        RefreshUI();
    }

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
    public void BindItem(ItemData item)
    {
        boundItem = item;
    }

    public void OnPointerEnter(PointerEventData e)
    {
        if (boundItem != null) UIManager.Instance.uiTooltip?.Show(boundItem, e.position);
    }

    public void OnPointerExit(PointerEventData e)
    {
        UIManager.Instance.uiTooltip?.Hide();
    }
    public void Clear()
    {
        boundItem = null;
        UIManager.Instance.uiTooltip?.Hide();
        cur = null;
        RefreshUI();
        SetEquipped(false);
    }
    public void SetEquipped(bool on)
    {
        if (equipBadge) equipBadge.gameObject.SetActive(on);
    }
}
