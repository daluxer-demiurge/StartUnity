using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    #region - ХП и жизни
    [SerializeField] private int _health;
    [SerializeField] private int _lifes;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        Destroy(gameObject);
        if (_lifes != 0) _lifes--;
        else print("Game is Over, dude =)");
    }
    #endregion
    #region - Controller
    [SerializeField] private float _mainSpeed = 100.0f;
    [SerializeField] private float _shiftAdd = 250.0f; 
    [SerializeField] private float _maxShift = 1000.0f; 
    [SerializeField] private float _camSens = 1f;
    private Vector3 _lastMouse = new Vector3(255, 255, 255); 
    private float _totalRun = 1.0f;

    void Update()
    {
        _lastMouse = Input.mousePosition - _lastMouse;
        _lastMouse = new Vector3(-_lastMouse.y * _camSens, _lastMouse.x * _camSens, 0);
        _lastMouse = new Vector3(transform.eulerAngles.x + _lastMouse.x, transform.eulerAngles.y + _lastMouse.y, 0);
        transform.eulerAngles = _lastMouse;
        _lastMouse = Input.mousePosition; 
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _totalRun += Time.deltaTime;
            p = p * _totalRun * _shiftAdd;
            p.x = Mathf.Clamp(p.x, -_maxShift, _maxShift);
            p.y = Mathf.Clamp(p.y, -_maxShift, _maxShift);
            p.z = Mathf.Clamp(p.z, -_maxShift, _maxShift);
        }
        else
        {
            _totalRun = Mathf.Clamp(_totalRun * 0.5f, 1f, 1000f);
            p *= _mainSpeed;
        }

        p *= Time.deltaTime;
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else
        {
            transform.Translate(p);
        }

    }

    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
    #endregion
}
