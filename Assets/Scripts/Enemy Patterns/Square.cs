using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : IEnemyPattern
{
    private Vector2Int[] directions = new Vector2Int[]
    {
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.up
    };

    private int currentDirIndex;
    private int stepCounter;
    private int distance;

    public Square(int distance, int startIndex)
    {
        this.distance = distance;
        this.currentDirIndex = startIndex % directions.Length;
        this.stepCounter = 0;
    }

    public void Initialize(EnemyContoller enemy)
    {
        
    }

    public Vector2Int GetDirection()
    {
        stepCounter++;
        if (stepCounter >= distance)
        {
            stepCounter = 0;
            currentDirIndex = (currentDirIndex + 1) % directions.Length;
        }

        return directions[currentDirIndex];
    }
}
