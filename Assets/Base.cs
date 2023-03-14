using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    public TextMeshPro healthText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;

            if (health < 0 )
            {
                health = 0;
                
                Debug.Log("Death");
            }
        }

        healthText.text = health.ToString();
    }
}
