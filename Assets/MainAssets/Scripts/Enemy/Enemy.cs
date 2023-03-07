using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]public int health;

    [SerializeField]private int damage;

    [SerializeField]private float speed;

    [SerializeField]private int giveCoin;

    [SerializeField] private int level;

    [SerializeField] private int attackDistance;
        
    [SerializeField] private Animator anim;

    private bool _canAttack;

    private GameObject _playerBase;

    
    private void Awake()
    {
        _playerBase = GameObject.FindWithTag("PlayerBase");
    }

    protected virtual void Attack()
    {
        //anim.SetBool("attack", true);
    }
    
    protected virtual void GetDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Debug.Log(gameObject.name + " Death");
        //anim.SetBool("death", true);
    }

    protected virtual void Move()
    {
        float dist = Vector3.Distance(_playerBase.transform.position, transform.position);

        if(dist > attackDistance)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        else
        {
            if (!_canAttack)
            {
                Attack();
                
                _canAttack = true;
            }
        }
    }

    protected virtual void Update()
    {
        
    }
}
