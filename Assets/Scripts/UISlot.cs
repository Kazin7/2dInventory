using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Button button;
    [SerializeField] GameObject equippedMark;

    [SerializeField] Graphic borderTarget;

    Sprite cur;
    Outline outline;

    public bool IsEmpty => cur == null;
    void Awake()
    {
        if (!button) button = GetComponentInChildren<Button>(true) ?? GetComponent<Button>();
        if (!icon)   icon   = transform.Find("Icon")?.GetComponent<Image>() ?? GetComponent<Image>();
        if (!borderTarget) borderTarget = GetComponent<Image>();

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
        if (!outline) return;
        outline.effectColor = Color.red;
        outline.effectDistance = new Vector2(3f, -3f);
        outline.enabled = on;
    }
}
