using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    [SerializeField]public Transform[] spawnPoints;

    [SerializeField]public GameObject[] ghosts;

    int randomSpawnPoint, randomMonster;

    public static bool spawnAllowed;

    [SerializeField]private float GhostCount =0f;
    
    [SerializeField]private float NumberofGhosts = 10f;

    public static float EnemiesAlive;

    public float SpawnTime = 2f;

    public float repeatRat = 3f;

    void Start()
    {
        EnemiesAlive = NumberofGhosts;

        spawnAllowed = true;
        InvokeRepeating("SpawnAGhost", SpawnTime, repeatRat);//time before spawn,repeat rate
    }

    void SpawnAGhost()
    {
        if (spawnAllowed)
        {
            GhostCount++;
 
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, ghosts.Length);
            Instantiate(ghosts[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            return;
        }
    }

    private void Update()
    {
        SpawnTime = SpawnTime - 1;
        repeatRat = repeatRat - 1;
        //for (GhostCount = NumberofGhosts; GhostCount == 0; GhostCount--)
        //{
        //    spawnAllowed = false;
        //}

        if (GhostCount >= NumberofGhosts)
        {
            spawnAllowed = false;
        }
    }
}

