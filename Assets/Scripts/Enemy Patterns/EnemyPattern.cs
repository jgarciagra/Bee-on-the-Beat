using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPattern : ScriptableObject
{
    public abstract Vector2Int GetDirection(EnemyContoller enemy);
}