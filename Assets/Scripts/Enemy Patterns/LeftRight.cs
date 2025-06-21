using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeftRight : IEnemyPattern
{
    private bool state;
    private bool initialRight;

    public void Initialize(EnemyContoller enemy)
    {
        initialRight = enemy.initialRight;
        state = initialRight;
    }

    public Vector2Int GetDirection()
    {
        Vector2Int dir;
        if (state)
        {
            dir = Vector2Int.right;
        }
        else
        {
            dir = Vector2Int.left;
        }
        state = !state;
        return dir;
    }
}
