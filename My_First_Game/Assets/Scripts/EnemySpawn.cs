using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    
    [SerializeField]
    private Transform _enemySpawnPoint;    
    
    void Start()
    {
        Instantiate(_enemy, _enemySpawnPoint.position, Quaternion.identity);
    }  

}
