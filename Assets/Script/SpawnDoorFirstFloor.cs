using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoorFirstFloor : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject[] doors;
    int  randomMonster;

    public float num_1;
    public float num_2;

    void Start()
    {
        InvokeRepeating("SpawnMonster", num_1, num_2);
    }
    void SpawnMonster()
    {
        randomMonster = Random.Range(0, doors.Length);
        Instantiate(doors[randomMonster], spawnPoints);
    }
}
