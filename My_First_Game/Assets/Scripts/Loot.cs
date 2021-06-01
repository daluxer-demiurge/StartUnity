using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public int health = 50;
    public int giftNumber;
    [SerializeField] private GameObject gift1;
    [SerializeField] private GameObject gift2;
    [SerializeField] private GameObject gift3;


    public void Hurt(int _damage)
    {
        health -= _damage;

        if (health <= 0)
        {
            giftNumber = Random.Range(0, 3);
            switch (giftNumber)
            {
                case 0:
                    Instantiate(gift1, GetComponent<Loot>().transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(gift2, GetComponent<Loot>().transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(gift3, GetComponent<Loot>().transform.position, Quaternion.identity);
                    break;
            }
            Destroy(gameObject);
        }
    }

        
}
