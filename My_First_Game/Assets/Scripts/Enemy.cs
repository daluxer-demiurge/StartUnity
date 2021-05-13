using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _health;
    NavMeshAgent navMeshAgent;
    PlayerSpawn player;
    Animator animator;
    bool dead;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerSpawn>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        if (dead)
            return;
    }

    public void Hurt(int damage)
    {     
        _health -= damage; ;

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
