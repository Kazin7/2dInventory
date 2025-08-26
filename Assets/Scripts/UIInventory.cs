using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    public Button backBtn;
    [SerializeField] public GameObject uiInventory;
    
    void Start()
    {
        if (UIManager.Instance.uiInventory == null)
            UIManager.Instance.uiInventory = this;
        if (uiInventory == null)
            uiInventory = this.gameObject;
        backBtn.onClick.AddListener(OnclickBack);
    }
    public void OnclickBack()
    {
        uiInventory.SetActive(false);
    }
}
