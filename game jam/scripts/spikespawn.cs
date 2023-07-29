using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float startAt = 30f;
    public player_script plmv;
    public float[] playerHealth, NewSpawnInterval;

    [HideInInspector] public player_script health;
    [HideInInspector] public float timer12 = 0f;
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            timer12 += Time.deltaTime;
        }

        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            if (timer12 > startAt)
            {
                GenerateRandomEnemy(enemyPrefabs);
                timer = 0f;

                for (int i = 0; i < playerHealth.Length; i++)
                {
                    if (plmv.health == playerHealth[i])
                    {
                        spawnInterval = NewSpawnInterval[i];
                    }
                }
            }
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
