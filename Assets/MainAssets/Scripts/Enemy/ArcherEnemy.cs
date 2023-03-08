using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy, IDamageable
{
    protected override void Attack()
    {
        Debug.Log("RangedAttacking");
    }

    public void GetDamage(int amount)
    {
        GetDamage(amount);
    }
}
