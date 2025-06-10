using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy Patterns/LeftRight")]
public class LeftRight : EnemyPattern
{
    public override Vector2Int GetDirection(EnemyContoller enemy)
    {
        if (!enemy.hasPatternInitialized)
        {
            enemy.customState = enemy.initialRight;
            enemy.hasPatternInitialized = true;
        }

        Vector2Int dir;

        if (enemy.customState)
            dir = Vector2Int.right;
        else
            dir = Vector2Int.left;

        enemy.customState = !enemy.customState;
        return dir;
    }
}
