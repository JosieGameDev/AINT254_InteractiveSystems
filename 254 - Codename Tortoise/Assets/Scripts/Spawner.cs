using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // vars
    public GameObject tortoisePrefab;
    public float spawnRate = 5f;
    private float lastSpawnTime;
    public int maxTortoiseInScene = 10;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkTortoiseInScene() < maxTortoiseInScene)
        {
            if (lastSpawnTime + spawnRate <= Time.time)
            {
                lastSpawnTime = Time.time;
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        Vector3 spawnPos = this.transform.position;
        Instantiate(tortoisePrefab,spawnPos, Quaternion.identity );
    }

    public int checkTortoiseInScene()
    {
        GameObject[] tortoises = GameObject.FindGameObjectsWithTag("tortoise");
        return tortoises.Length;
    }
}
