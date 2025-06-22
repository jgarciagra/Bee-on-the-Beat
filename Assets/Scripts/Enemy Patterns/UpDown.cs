using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Patterns/UpDown")]
public class UpDown : EnemyPattern
{
    
    public override Vector2Int GetDirection(EnemyContoller enemy)
    {
        if (!enemy.hasPatternInitialized)
        {
            enemy.customState = enemy.initialUp;
            enemy.hasPatternInitialized = true;
        }
        Vector2Int dir;

        if (enemy.customState)
        {
            dir = Vector2Int.up;
        }
        else
        {
            dir = Vector2Int.down;
        }

        enemy.customState = !enemy.customState;
        return dir;
    }

}
