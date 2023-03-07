using UnityEngine;

public class MeleeEnemy : Enemy, IDamageable
{
    protected override void Attack()
    {
        Debug.Log("MeleeChampAttacking");
    }
    
    protected override void Update()
    {
        Move();
    }

    public void GetDamage(int amount)
    {
        GetDamage(amount);
    }
}
