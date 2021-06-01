using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public int _enemyHealth = 100;    
    [SerializeField] private int _enemyDamage = 50;
    NavMeshAgent navMeshAgent;
    Player player;
    Animator animator;
    bool dead;
    public float attackRate = 15.0f;
    private float nextAttackTime = 0f;
    public ParticleSystem bloodFlash;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 50.0f)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

    public void Hurt(int _damage)
    {
        _enemyHealth -= _damage;
        Debug.Log("ÆÈÇÍÈ ÏÐÎÒÈÂÍÈÊÀ - " + _enemyHealth);

        if (_enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("enemy died");
        if (!dead)
        {
            dead = true;
            bloodFlash.Play();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time > nextAttackTime) 
        {
            nextAttackTime = Time.time + 1f / attackRate;
            animator.SetTrigger("attack");
            player = other.GetComponent<Player>();
            player.Hurt(_enemyDamage);            

        }

    }
    
}
