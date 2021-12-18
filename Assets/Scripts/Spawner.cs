using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType { spawnAfterSpawn, spawnAfterDeath };

public class Spawner : MonoBehaviour
{
    public LevelTimer levelTimer;
    public GameObject spawnedGameObject;
       
    //Spawn area
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public bool spawnArea;

    // Number of seconds to wait to spawn
    public int spawnInterval;

    // Number of times to spawn (-1 for infinite)
    public int spawnCount; 

    public SpawnType spawnType;

    Vector3 startPosition;

    private bool spawning = true;

    int seconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = spawnedGameObject.transform.position;
        spawnedGameObject.SetActive(false);
        //Set first object to inactive so it doesn't destroy the spawnedGameObject reference so clones can be created

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            if (spawnType == SpawnType.spawnAfterSpawn)
            {
                // Only spawn the first time that a new second ticks over
                if (levelTimer.GetSeconds() > seconds && levelTimer.GetSeconds() % spawnInterval == 0)
                {
                    Spawn();
                }
            }
            seconds = levelTimer.GetSeconds();
            if (spawnCount == 0)
            {
                spawning = false;
            }
        }
    }

    public void Spawn()
    {
        if (spawnArea)
        {
            startPosition = GetRandomPosition();
        }
        Instantiate(spawnedGameObject, startPosition, Quaternion.identity).SetActive(true);
        spawnCount--;
    }

    Vector2 GetRandomPosition()
    {
        Debug.Log("Spawner");
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }
}


