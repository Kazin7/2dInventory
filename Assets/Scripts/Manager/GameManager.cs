using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character player;

    [Header("아이템 데이터 리스트 (ScriptableObject)")]
    [SerializeField] List<ItemData> itemDataList = new();

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        if (!player) player = FindObjectOfType<Character>();
        SetData();
    }

    public void SetData()
    {
        if (!player) return;
        player.SetUp("김영식");

        foreach (var data in itemDataList)
        {
            if (data != null)
                player.AddItem(data);
        }
    }
}

