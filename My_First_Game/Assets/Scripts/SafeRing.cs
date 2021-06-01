using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRing : MonoBehaviour
{
    [SerializeField] private int _safeRingDamage = 1000;
    private bool _occupiedPoint = false;
   
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _occupiedPoint = true;            
        }

        if (_occupiedPoint = true && other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.Hurt(_safeRingDamage);
            Destroy(gameObject);
        }
    }
}
