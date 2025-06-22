using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Patterns/Square")]
public class Square : EnemyPattern
{
    private static readonly Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public override Vector2Int GetDirection(EnemyContoller enemy)
    {
        if (!enemy.hasPatternInitialized)
        {
            enemy.customStep = enemy.startStep % directions.Length;
            enemy.hasPatternInitialized = true;
        }

        Vector2Int dir = directions[enemy.customStep];
        enemy.customStep = (enemy.customStep + 1) % directions.Length;
        return dir;
    }
}
