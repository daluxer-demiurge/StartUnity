using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
   
    public Transform _playerSpawnPoint;

    void Start()
    {
        Instantiate(_player, _playerSpawnPoint.position, Quaternion.identity);
    }

}