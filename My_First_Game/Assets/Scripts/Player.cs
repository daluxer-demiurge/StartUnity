using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{    
    #region - �� � �����
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

   

    [SerializeField] private float _mainSpeed = 1.5f;

    public Transform head;

    [SerializeField] private float _camSens = 5f; 
    private float headMinY = -40f; 
    private float headMaxY = 40f;

    public KeyCode jumpButton = KeyCode.Space;
    public float jumpForce = 10; 
    public float jumpDistance = 1.2f; 

    private Vector3 direction;
    private float h, v;
    private int layerMask;
    private Rigidbody body;
    private float rotationY;

    void Start()
    {        
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        layerMask = 1 << gameObject.layer | 1 << 2;
        layerMask = ~layerMask;
    }

    void FixedUpdate()
    {
        body.AddForce(direction * _mainSpeed , ForceMode.VelocityChange);

        // ����������� ��������, ����� ������ ����� ��������� ����������
        if (Mathf.Abs(body.velocity.x) > _mainSpeed )
        {
            body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * _mainSpeed , body.velocity.y, body.velocity.z);
        }
        if (Mathf.Abs(body.velocity.z) > _mainSpeed )
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * _mainSpeed );
        }
    }

    bool WantJump() // �������� ���������� ��� ������
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out _, jumpDistance, layerMask))
        {
            return true;
        }

        return false;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        #region - ���������� ������� (�������)
        float rotationX = head.localEulerAngles.y + Input.GetAxis("Mouse X") * _camSens ;
        rotationY += Input.GetAxis("Mouse Y") * _camSens ;
        rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
        head.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        #endregion

        #region - ����������� ��������
        direction = new Vector3(h, 0, v);
        direction = head.TransformDirection(direction);
        direction = new Vector3(direction.x, 0, direction.z);
        #endregion

        if (Input.GetKeyDown(jumpButton) && WantJump())
        {
            body.velocity = new Vector2(0, jumpForce);
        }
    }

    void OnDrawGizmosSelected() // ���������, ��� ���������� ��������� jumpDistance
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * jumpDistance);
    }
}