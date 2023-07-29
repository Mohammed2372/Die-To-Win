
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

    [HideInInspector] public player_script health;
    public float startAt = 30f;
    public float destroyAt = 3f;
    public player_script plmv;
    public float[] playerHealth, NewSpawnInterval;

    [HideInInspector] public float timer12 = 0f;
    GameObject enemyInstance;
    //public int healthp = health.health;
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

                for (int i = 0; i < playerHealth.Length; i++)
                {
                    if (plmv.health == playerHealth[i])
                    {
                        spawnInterval = NewSpawnInterval[i];
                    }
                }
            }

        }
        if(timer > destroyAt)
        {
            Destroy(enemyInstance);
        }
    }
    private GameObject GenerateRandomSaw(GameObject enemyPrefab, GameObject enemyInstance)
    {
        int random = Random.Range(-number, number);
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