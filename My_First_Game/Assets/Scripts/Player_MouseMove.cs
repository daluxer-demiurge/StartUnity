using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MouseMove : MonoBehaviour
{
    #region - контроллер мыши
    private float _xRotation;
    private float _yRotation;
    private float _xRotationCurrent;
    private float _yRotationCurrent;
    [SerializeField] private Camera _player;
    public GameObject playerGameObject;
    [SerializeField] private float _camSensitivity = 5f;
    private float _smoothTime = 0.1f;
    private float _currentVelosityX;
    private float _currentVelosityY;

    void Update()
    {
        MouseMove();
    }
    void MouseMove()
    {
        _xRotation += Input.GetAxis("Mouse X") * _camSensitivity;
        _yRotation += Input.GetAxis("Mouse Y") * _camSensitivity;
        _yRotation = Mathf.Clamp(_yRotation, -90, 90);

        _xRotationCurrent = Mathf.SmoothDamp(_xRotationCurrent, _xRotation, ref _currentVelosityX, _smoothTime);
        _yRotationCurrent = Mathf.SmoothDamp(_yRotationCurrent, _yRotation, ref _currentVelosityY, _smoothTime);
        _player.transform.rotation = Quaternion.Euler(-_yRotationCurrent, _xRotationCurrent, 0f);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, _xRotationCurrent, 0f);
    }
    #endregion
}
