using System.Collections;
using TMPro;
using UnityEngine;

public class ArcherEnemy : Enemy, IDamageable
{
    private bool attack;
    
    public TextMeshPro healthText;
    
    
    protected override void Attack()
    {
        if (!attack)
        {
            _playerBase.GetDamage(10);
            
            attack = true;
            
            StartCoroutine(WaitForFunction());
        }
    }
    
    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(1);
      
        attack = false;
    }

    public void GetDamage(int amount)
    {
        IncreaseHealth(amount);
        
        healthText.text = health.ToString();
    }
}
