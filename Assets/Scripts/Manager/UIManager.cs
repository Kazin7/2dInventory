using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] public UIStatus uiStatus;
    [SerializeField] public UIInventory uiInventory;
    [SerializeField] public UIExpBar uiExpBar;
    [SerializeField] public UITooltip uiTooltip;
    [SerializeField] UITooltip tooltipPrefab;
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        MakeTooltip();
        DontDestroyOnLoad(gameObject);
    }
    //각각 UI를 못찾았을 경우 Find함수 사용해서 가져옴
    void Start()
    {
        if (uiStatus == null) uiStatus = FindObjectOfType<UIStatus>(true);
        if (uiInventory == null) uiInventory = FindObjectOfType<UIInventory>(true);
        if (uiExpBar == null) uiExpBar = FindObjectOfType<UIExpBar>(true);
        if (uiTooltip == null) uiTooltip = FindObjectOfType<UITooltip>(true);
    }
    //툴팁 제작하여 활성화 시키는 함수
    public void MakeTooltip()
    {
        if (uiTooltip != null) return;

        if (tooltipPrefab != null)
        {
            Transform parent = null;
            parent = this.transform;

            uiTooltip = Instantiate(tooltipPrefab, parent);
            uiTooltip.gameObject.SetActive(false);
            return;
        }
    }
}
