using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed; // �������� ��������, � � ���������� ���������
    [SerializeField] private Vector3 _direction; // ����������� ��������

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        var speed = _direction * _speed * Time.deltaTime;
        transform.Translate(speed);
    }


}
