using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _health;
    NavMeshAgent navMeshAgent;
    Player player;
    Animator animator;
    bool dead;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);        
    }

    public void Hurt(float _damage)
    {     
        _health -= _damage; ;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!dead)
        {
            dead = true;
            Destroy(gameObject);
            animator.SetTrigger("died");
        }
    }

   

    }
