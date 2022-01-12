using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall_1stFloor : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject ball;

    public float num_1;
    public float num_2;

    public bool fireBall = false;
    void Start()
    {
        InvokeRepeating("SpawnMonster", num_1, num_2);
    }

    void SpawnMonster()
    {
        if (fireBall)
        {
            Instantiate(ball, spawnPoints);
            fireBall = false;
        }

    }

}
