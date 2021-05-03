using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] obstacles;
    public GameObject token;
    public float timeBetweenSpawns, timeReduce, minTimeBetweenSpawns;
    public int tokenSpawnFrequency = 5;

	void Start ()
    {
        Spawn();
	}

    public void Spawn()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform.position, Quaternion.identity);

        if (!(FindObjectOfType<Collision>().gameIsOver))
        {
            Invoke("Spawn", timeBetweenSpawns);
            if (Random.Range(0, tokenSpawnFrequency) == 0)
            {
                Invoke("SpawnToken", timeBetweenSpawns / 2f);
            }

        }
            if ((timeBetweenSpawns - timeReduce) >= minTimeBetweenSpawns)
            {
                timeBetweenSpawns -= timeReduce;
            }
    }

    public void SpawnToken()
    {
        Instantiate(token, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
    }
}
