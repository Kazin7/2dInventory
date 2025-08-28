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
    [SerializeField] string tooltipCanvasName = "UITooltip";
    void Awake()
    {
        if (Instance != null) return;

        Instance = this;
        MakeTooltip();
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (uiStatus == null) uiStatus = FindObjectOfType<UIStatus>(true);
        if (uiInventory == null) uiInventory = FindObjectOfType<UIInventory>(true);
        if (uiExpBar == null) uiExpBar = FindObjectOfType<UIExpBar>(true);
        if (uiTooltip == null) uiTooltip = FindObjectOfType<UITooltip>(true);
    }
    public void MakeTooltip()
    {
        if (uiTooltip != null) return;

        uiTooltip = FindObjectOfType<UITooltip>(true);
        if (uiTooltip != null) return;

        if (tooltipPrefab != null)
        {
            Transform parent = null;
            var tipCanvas = GameObject.Find(tooltipCanvasName);
            if (tipCanvas) parent = tipCanvas.transform;

            uiTooltip = Instantiate(tooltipPrefab, parent);
            uiTooltip.gameObject.SetActive(false);
            return;
        }
    }
}
