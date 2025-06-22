using UnityEngine;

public abstract class EnemyPattern : ScriptableObject
{
    public abstract IEnemyPattern CreateInstance();
}