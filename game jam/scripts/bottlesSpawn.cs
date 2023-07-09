using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bottlesSpawn : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject[] enemyPrefabs;

    public float spawnInterval = 7f;
    private float timer = 0f;
  

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateRandomEnemy();
            timer = 0f;
        }
    }
    private GameObject GenerateRandomEnemy()
    {
        int randomIndex = Random.Range(0, 4);
        GameObject enemyPrefab;
        Vector3 spawnPosition = Vector3.zero;

        // Top border
        spawnPosition = new Vector3(Random.Range(-8.15f, 8.15f), 4.1f, 0f);
        transform.TransformVector(0, -Speed, 0);

        if(randomIndex > 3)
        {
            enemyPrefab = enemyPrefabs[0];
        }
        else
        {
            enemyPrefab = enemyPrefabs[1];
        }
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = enemyInstance.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -Speed);

        return enemyPrefab;
    }
}

