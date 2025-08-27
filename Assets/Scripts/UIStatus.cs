using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIStatus : MonoBehaviour
{
    public TMP_Text attackText;
    public TMP_Text shieldText;
    public TMP_Text healthText;
    public TMP_Text criticalText;
    public Button backBtn;
    [SerializeField] public GameObject uiStatus;

    void Start()
    {
        if (UIManager.Instance.uiStatus == null)
            UIManager.Instance.uiStatus = this;
        if (uiStatus == null)
            uiStatus = this.gameObject;
        SetCharacterInfo(GameManager.Instance.player);
        backBtn.onClick.AddListener(OnclickBack);
    }
    public void SetCharacterInfo(Character c)
    {
        if (c == null) return;
        attackText.text   = $"{c.Attack}";
        shieldText.text   = $"{c.Shield}";
        healthText.text   = $"{c.Health}";
        criticalText.text = $"{c.Critical}";
    }
    public void OnclickBack()
    {
        uiStatus.SetActive(false);
    }
}
