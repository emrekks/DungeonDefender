using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rb;

    public int damage;
    
    public int speed;
   
    private void Awake()
    {   
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rb.velocity = transform.forward * speed;
        
        Invoke("BackToPool", 3);
    }

    private void BackToPool()
    {
        ObjectPool.Instance.BackToPoolObject(gameObject, 1);
       
        _rb.velocity = Vector3.zero;
        
        DOTween.Kill(gameObject);           //silinicek
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.GetDamage(damage);
          
            BackToPool();
        }
    }
}
