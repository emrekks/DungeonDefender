using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ArcherEnemy : Enemy, IDamageable
{
    private bool attack;

    public Transform fp;
    
    public TextMeshPro healthText;


    protected override void Attack()
    {
        if (!attack)
        {
            ObjectPool.Instance.GetPooledObject(1, fp, new Vector3(0,-90,0));
            
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
