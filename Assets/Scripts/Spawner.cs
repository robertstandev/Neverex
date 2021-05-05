using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject[] obstacles;
    [SerializeField]private GameObject token;
    [SerializeField]private float timeBetweenSpawns, timeReduce, minTimeBetweenSpawns;
    [SerializeField]private int tokenSpawnFrequency = 5;

	private void Start () { spawn(); }

    private void spawn()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform.position, Quaternion.identity);

        if (!(FindObjectOfType<Collision>().isGameOver()))
        {
            Invoke("spawn", timeBetweenSpawns);
            if (Random.Range(0, tokenSpawnFrequency) == 0)
            {
                Invoke("spawnToken", timeBetweenSpawns / 2f);
            }

        }
            if ((timeBetweenSpawns - timeReduce) >= minTimeBetweenSpawns)
            {
                timeBetweenSpawns -= timeReduce;
            }
    }

    private void spawnToken() { Instantiate(token, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f))); }
}