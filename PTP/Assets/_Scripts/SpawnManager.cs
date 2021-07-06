using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;

    [SerializeField] private float spawnRate;

    private float timeToNextSpawn;

    private void Start()
    {
        timeToNextSpawn = Time.time + spawnRate;
    }

    private void Update()   // ABSTRACTION
    {
        Spawn();
    }

    private void Spawn()
    {

        if (timeToNextSpawn <= Time.time)
        {
            int ndx = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[ndx], transform.position, prefabs[ndx].transform.rotation);

            timeToNextSpawn = Time.time + spawnRate;
        }
    }
}
