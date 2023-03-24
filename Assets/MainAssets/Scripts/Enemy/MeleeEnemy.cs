using TMPro;
using UnityEngine;

public class MeleeEnemy : Enemy, IDamageable
{
    public TextMeshPro healthText;

    protected override void Attack()
    {
        Debug.Log("MeleeChampAttacking");
    }

    public void GetDamage(int amount)
    {
        IncreaseHealth(amount);

        healthText.text = health.ToString();
    }
}
