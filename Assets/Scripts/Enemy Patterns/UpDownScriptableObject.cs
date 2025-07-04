using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Patterns/UpDown")]
public class UpDownScriptableObject : EnemyPattern
{
    public override IEnemyPattern CreateInstance()
    {
        return new UpDown();
    }
}