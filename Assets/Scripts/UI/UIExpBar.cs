using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIExpBar : MonoBehaviour
{
    [SerializeField] private Image fill;
    [SerializeField] private TMP_Text nowExpText;
    [SerializeField] private TMP_Text maxExpText;

    public void SetExp(int exp, int maxExp)
    {
        exp = Mathf.Max(0, exp);
        maxExp = Mathf.Max(1, maxExp);

        if (fill)       fill.fillAmount = Mathf.Clamp01((float)exp / maxExp);
        if (nowExpText) nowExpText.text = exp.ToString();
        if (maxExpText) maxExpText.text = maxExp.ToString();
    }
}
