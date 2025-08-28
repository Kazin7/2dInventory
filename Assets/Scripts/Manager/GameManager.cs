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
        //인스턴스 예외처리
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        //플레이어 정보가 없을경우 찾아옴
        if (!player) player = FindObjectOfType<Character>();

        SetData();
    }
    //플레이어정보,아이템정보 설정
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

