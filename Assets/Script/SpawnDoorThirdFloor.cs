using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoorThirdFloor : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject[] doors;
    int randomMonster;

    public float num_1;
    public float num_2;


    void Start()
    {
        InvokeRepeating("SpawnMonster", num_1, num_2);
    }

    void SpawnMonster()
    {
        //randomSpawnPoint = Random.Range(0, spawnPoints.childCount);
        randomMonster = Random.Range(0, doors.Length);
        Instantiate(doors[randomMonster], spawnPoints);
    }
}
