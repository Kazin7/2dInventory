using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusBtn;
    [SerializeField] private Button inventoryBtn;
    public TMP_Text levelText;
    public TMP_Text NameText;
    void Start()
    {
        //버튼 이벤트 연결, 캐릭터 정보 가져와서 텍스트 연결
        statusBtn.onClick.AddListener(OpenStatus);
        inventoryBtn.onClick.AddListener(OpenInventory);
        SetCharacterInfo(GameManager.Instance.player);
    }
    public void SetCharacterInfo(Character c)
    {
        if (c == null) return;
        NameText.text = $"{c.Name}";
        levelText.text = $"{c.Level}";
        UIManager.Instance.uiExpBar.SetExp(c.Exp, c.MaxExp);
    }
    void OpenMainMenu()//조건에 있어야한다고 해서 넣었는데 어디에 사용해야할지 모르겠음
    {

    }
    //스테이터스 버튼 클릭 이벤트
    void OpenStatus()
    {
        UIManager.Instance.uiStatus.uiStatus.SetActive(true);
        UIManager.Instance.uiStatus.SetCharacterInfo(GameManager.Instance.player);
    }
    //인벤토리 버튼 클릭 이벤트
    void OpenInventory()
    {
        UIManager.Instance.uiInventory.uiInventory.SetActive(true);
    }
}
