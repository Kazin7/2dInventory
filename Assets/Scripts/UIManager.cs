using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] public UIStatus uiStatus;
    [SerializeField] public UIInventory uiInventory;
    [SerializeField] public UIExpBar uiExpBar;

    void Awake()
    {
        if (Instance != null) return;

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (uiStatus == null) uiStatus = FindObjectOfType<UIStatus>(true);
        if (uiInventory == null) uiInventory = FindObjectOfType<UIInventory>(true);
        if (uiExpBar == null) uiExpBar = FindObjectOfType<UIExpBar>(true);
    }
}
