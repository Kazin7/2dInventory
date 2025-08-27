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
    void OpenMainMenu()//뭘하는지모르겠음
    {

    }
    void OpenStatus()
    {
        UIManager.Instance.uiStatus.uiStatus.SetActive(true);
    }
    void OpenInventory()
    {
        UIManager.Instance.uiInventory.uiInventory.SetActive(true);
    }
}
