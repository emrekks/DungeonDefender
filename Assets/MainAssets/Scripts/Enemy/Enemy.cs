using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public int health;

    [SerializeField] private int damage;

    [SerializeField] private float speed;

    [SerializeField] private int giveCoin;

    [SerializeField] private int level;

    [SerializeField] private float attackDistance;
        
    [SerializeField] private Animator anim;

    private bool _canAttack;

    protected Base _playerBase;

    
    private void Awake()
    {
        _playerBase = FindObjectOfType<Base>();
    }

    protected virtual void Attack()
    {
        //anim.SetBool("attack", true);
    }

    protected void IncreaseHealth(int amount)
    {
        if (health > 0)
        {
            health -= amount;
        }

        else
        {
            Death();
        }
    }

    protected void Death()
    {
        Debug.Log(gameObject.name + " Death");
        
        //anim.SetBool("death", true);
    }

    protected void Move()
    {
        float dist = Mathf.Abs(_playerBase.transform.position.x - transform.position.x);

        if(dist > attackDistance)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        else
        {
            if (!_canAttack)
            {
                Attack();
                
                //_canAttack = true;
            }
        }
    }

    protected virtual void Update()
    {
        Move();
    }
}
