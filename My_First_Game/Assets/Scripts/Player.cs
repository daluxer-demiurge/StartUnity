using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    Animator animator;
    #region - ХП и жизни
    [SerializeField] private int _playerHealth;
    [SerializeField] private int _playerLifes;
    private int _curentPlayerHealth;
    private int _curentPlayerLifes;

    void Start()
    {
        _curentPlayerHealth = _playerHealth;
        _curentPlayerHealth = _curentPlayerLifes;
        animator = GetComponentInChildren<Animator>();
    }

    public void Hurt(int _damage)
    {
        _curentPlayerHealth -= _damage; ;

        if (_curentPlayerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("died");

        //ограничение движения из-за смерти персонажа
        if (Input.GetKey(KeyCode.W)) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 0f);
        if (Input.GetKey(KeyCode.S)) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 0f);
        if (Input.GetKey(KeyCode.A)) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 0f);
        if (Input.GetKey(KeyCode.D)) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 0f);

        if (_curentPlayerLifes != 0)
        {
            _curentPlayerLifes--;
            animator.SetTrigger("idle");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        }
    }
    #endregion
}

