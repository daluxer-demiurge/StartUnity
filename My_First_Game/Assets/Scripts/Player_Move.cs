using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    #region - контроллер клавиатуры
    [SerializeField] private float _mainSpeed;
    [SerializeField] private float _shiftSpeed;
    public float _currentSpeed;
    public float _x_Move;
    public float _z_Move;
    CharacterController player;
    Vector3 moveDirection;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        _x_Move = Input.GetAxis("Horizontal");
        _z_Move = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            moveDirection = new Vector3(_x_Move, 0f, _z_Move);
            moveDirection = transform.TransformDirection(moveDirection);
        }
        moveDirection.y -= 1;
        if (Input.GetKey(KeyCode.LeftShift)) _currentSpeed = _shiftSpeed;
        else _currentSpeed = _mainSpeed;
        player.Move(moveDirection * _currentSpeed);
    }
    #endregion
}
