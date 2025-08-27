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

    public void SetUp(
        string name = null,
        int? level = null,
        int? exp = null,
        int? attack = null,
        int? shield = null,
        int? health = null,
        int? critical = null)
    {
        if (name    != null) Name    = name;
        if (level   != null) Level   = level.Value;
        if (exp     != null) Exp     = exp.Value;
        if (attack  != null) Attack  = attack.Value;
        if (shield  != null) Shield  = shield.Value;
        if (health  != null) Health  = health.Value;
        if (critical!= null) Critical= critical.Value;

        MaxExp = Level * 3;
    }

}
