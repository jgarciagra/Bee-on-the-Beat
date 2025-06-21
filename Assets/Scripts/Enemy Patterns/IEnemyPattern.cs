using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyPattern
{
    void Initialize(EnemyContoller enemy);
    Vector2Int GetDirection();
}
