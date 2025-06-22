using UnityEngine;

public class UpDown : IEnemyPattern
{
    private bool state;
    private bool initialUp;

    public void Initialize(EnemyContoller enemy)
    {
        initialUp = enemy.initialUp;
        state = initialUp;
    }

    public Vector2Int GetDirection()
    {
        Vector2Int dir;
        if (state)
        {
            dir = Vector2Int.up;
        }
        else
        {
            dir = Vector2Int.down;
        }
        state = !state;
        return dir;
    }
}
