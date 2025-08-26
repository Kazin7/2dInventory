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
        attackText.text = UIManager.Instance.character.Attack.ToString();
        shieldText.text = UIManager.Instance.character.Shield.ToString();
        healthText.text = UIManager.Instance.character.Health.ToString();
        criticalText.text = UIManager.Instance.character.Critical.ToString();
        backBtn.onClick.AddListener(OnclickBack);
    }

    public void OnclickBack()
    {
        uiStatus.SetActive(false);
    }
}
