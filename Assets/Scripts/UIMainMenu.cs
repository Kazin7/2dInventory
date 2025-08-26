using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusBtn;
    [SerializeField] private Button inventoryBtn;
    void Start()
    {
        statusBtn.onClick.AddListener(OpenStatus);
        inventoryBtn.onClick.AddListener(OpenInventory);
        UIManager.Instance.uiExpBar.SetExp(UIManager.Instance.character.Exp, UIManager.Instance.character.MaxExp);
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
