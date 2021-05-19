using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{    
    #region - ХП и жизни
    [SerializeField] private float _health;
    [SerializeField] private float _lifes;
       
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
        if (_lifes != 0) _lifes--;
        else print("Game is Over, dude =)");
        Destroy(gameObject);
    }
    #endregion
}