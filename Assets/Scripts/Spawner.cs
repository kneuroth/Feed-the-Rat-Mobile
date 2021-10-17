using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType { spawnAfterSpawn, spawnAfterDeath };

public class Spawner : MonoBehaviour
{
    public LevelTimer levelTimer;
    public GameObject gameObject;
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
        startPosition = gameObject.transform.position;
        gameObject.SetActive(false);
        //Set first object to inactive so it doesn't destroy the gameObject reference so clones can be created

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
        Instantiate(gameObject, startPosition, Quaternion.identity).SetActive(true);
        spawnCount--;
    }
}


