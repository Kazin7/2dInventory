using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name { get; private set; } = "Chad";
    public int Level { get; private set; } = 10;
    public int Exp { get; private set; } = 9;
    public int MaxExp;
    public int Attack { get; private set; } = 35;
    public int Shield { get; private set; } = 40;
    public int Health { get; private set; } = 100;
    public int Critical { get; private set; } = 25;

    void Start()
    {
        if (UIManager.Instance.character == null)
            UIManager.Instance.character = this;
        MaxExp = Level * 3;
    }
}
