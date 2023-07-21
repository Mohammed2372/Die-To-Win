using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SawSpawner : MonoBehaviour
{
    Vector3 spawnPosition = Vector3.zero;
    public GameObject enemyPrefabs;
    public float width = 20f;
    public float height = 1f;
   

    public float spawnInterval = 3f;
    private float timer = 0f;
    private int number = 2;

    public float startAt = 30f;
    [HideInInspector] public float timer12 = 0f;
    GameObject enemyInstance;
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
                GenerateRandomSaw(enemyPrefabs, enemyInstance);
                timer = 0f;

                if (timer12 > 60)
                {
                    spawnInterval = 6;
                }
                if (timer12 > 90)
                {
                    spawnInterval = 5;
                }
            }

        }
    }
    private GameObject GenerateRandomSaw(GameObject enemyPrefab, GameObject enemyInstance)
    {
        int random = Random.Range(-number, number + 1);
        Debug.Log(random);
        switch (random)
        {
            case -2:
                spawnPosition = new Vector3(Random.Range(-width, width), height * random, 0f);
                enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                timer = 0f;
                break;
            case -1:
                spawnPosition = new Vector3(Random.Range(-width, width), height * random, 0f);
                enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                timer = 0f;
                break;
            case 0:
                spawnPosition = new Vector3(Random.Range(-width, width), height * random, 0f);
                enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                timer = 0f;
                break;
            case 1:
                spawnPosition = new Vector3(Random.Range(-width, width), height * random, 0f);
                enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                timer = 0f;
                break;
            case 2:
                spawnPosition = new Vector3(Random.Range(-width, width), height * random, 0f);
                enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                timer = 0f;
                break;
            case 3:
                spawnPosition = new Vector3(Random.Range(-width, width), height * random, 0f);
                enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                timer = 0f;
                break;
        }
        return enemyInstance;
    }
}
