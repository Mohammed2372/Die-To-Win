using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class spikespawn : MonoBehaviour
{
    public GameObject enemyPrefabs;
    Vector3 spawnPosition = Vector3.zero;
    public float gameAreaWidth = 10f;

    public float spawnInterval = 4f;
    public float destroyinterval = 2f;
    private float timer = 0f;
    //private float timer1 = 0f;
    public float gameAreaHeight = 5f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 8)
        {
            GenerateRandomEnemy(enemyPrefabs);
            timer = 0f;
        }
    }
    private GameObject GenerateRandomEnemy(GameObject enemyPrefabs)
    {
        Vector3 spawnPosition = Vector3.zero;
        // Set the spawn position based on the selected border
        spawnPosition = new Vector3(Random.Range(-gameAreaWidth, gameAreaWidth), -4.08f, 0f);

        GameObject enemyInstance = Instantiate(enemyPrefabs, spawnPosition, Quaternion.identity);

        return enemyInstance;
    }
}
