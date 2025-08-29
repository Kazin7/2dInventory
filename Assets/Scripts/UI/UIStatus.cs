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
        //플레이어 정보를 가져와서 세팅
        SetCharacterInfo(GameManager.Instance.player);
        backBtn.onClick.AddListener(OnclickBack);
    }
    //플레이어 스탯 설정
    public void SetCharacterInfo(Character c)
    {
        if (c == null) return;
        attackText.text = $"{c.Attack}";
        shieldText.text = $"{c.Shield}";
        healthText.text = $"{c.Health}";
        criticalText.text = $"{c.Critical}";
    }
    //뒤로가기
    public void OnclickBack()
    {
        uiStatus.SetActive(false);
    }
}
