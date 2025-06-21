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
    public int distance;
    public StartDirection initialDirection;

    public override IEnemyPattern CreateInstance()
    {
        return new Square(distance, (int)initialDirection);
    }
}