using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Enemy Prefabs
    public List<GameObject> prefabs;

    //Enemy Spawn Point
    public List<Transform> spawnPoints;

    // Enemy Spawn Interval
    public float spawnInterval = 2f;

    public void StartSpawning()
    {
        //Call the spawn core routine
        StartCoroutine(SpawnDelay());  
    }

    IEnumerator SpawnDelay()
    {
        // Call the spawn method
        SpawnEnemy();
        // Wait interval 
        yield return new WaitForSeconds(spawnInterval);
        // Call core routine
        StartCoroutine(SpawnDelay());
    }

    public void SpawnEnemy()
    {
        // randomize spawned 
        int randomPrefabID = Random.Range(0, prefabs.Count);

        // randomize spawn point 
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);

        //Instantiate enemy prefab
        GameObject SpawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);


    }

}
