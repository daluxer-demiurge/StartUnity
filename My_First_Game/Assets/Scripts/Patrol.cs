using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speedPatrol;
    public Transform[] moveSpots;
    private int randomSpot;
    private float _waitTime;
    public float startWaitTime;

    private void Start()
    {
        _waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position,speedPatrol * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.5f)
        {
        if(_waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                _waitTime = startWaitTime;
            }
        else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
