using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Button button;
    [SerializeField] RectTransform equipBadge;

    [SerializeField] Graphic borderTarget;

    Sprite cur;
    Outline outline;

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

    public void Clear()
    {
        cur = null;
        RefreshUI();
        SetEquipped(false);
    }
    public void SetEquipped(bool on)
    {
        if (equipBadge) equipBadge.gameObject.SetActive(on);
    }
}
