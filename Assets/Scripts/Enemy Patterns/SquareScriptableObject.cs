using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StartDirection
{
    Right = 0,
    Down = 1,
    Left = 2,
    Up = 3
}

[CreateAssetMenu(menuName = "Enemy Patterns/Square")]
public class SquareScriptableObject : EnemyPattern
{
    
    public StartDirection initialDirection;

    public override IEnemyPattern CreateInstance()
    {
        return new Square(1, (int)initialDirection);
    }
}