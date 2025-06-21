using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Patterns/LeftRight")]
public class LeftRightScriptavleObject : EnemyPattern
{
    public override IEnemyPattern CreateInstance()
    {
        return new LeftRight();
    }
}
