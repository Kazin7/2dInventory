// UITooltip.cs
using UnityEngine;
using TMPro;

public class UITooltip : MonoBehaviour
{
    [SerializeField] RectTransform root;           // self
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI content;

    Canvas canvas;

    void Awake()
    {
        if (!root) root = transform as RectTransform;
        canvas = GetComponentInParent<Canvas>();
        Hide();
    }

    public void Show(Item item, Vector2 screenPos)
    {
        if (item == null) { Hide(); return; }

        title.text = string.IsNullOrEmpty(item.id) ? item.type.ToString() : item.id;

        System.Text.StringBuilder sb = new();
        if (item.attackBonus != 0) sb.AppendLine($"+ATK {item.attackBonus}");
        if (item.shieldBonus != 0) sb.AppendLine($"+Shield {item.shieldBonus}");
        if (item.healthBonus != 0) sb.AppendLine($"+HP {item.healthBonus}");
        content.text = sb.ToString().TrimEnd();

        gameObject.SetActive(true);
    }


    public void Hide() => gameObject.SetActive(false);
}
