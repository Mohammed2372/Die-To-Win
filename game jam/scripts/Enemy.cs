using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject[] enemyPrefabs;
    private GameObject GenerateRandomEnemy()
    {
        int randomIndex = 0;

        // Determine which border the enemy will spawn on
        int randomBorder = Random.Range(0, 3);


        Vector3 spawnPosition = Vector3.zero;
        Quaternion spawnRotation = Quaternion.identity;

        // Set the spawn position based on the selected border
        switch (randomBorder)
        {
            case 0: // Top border
                spawnPosition = new Vector3(Random.Range(-gameAreaWidth / 2f, gameAreaWidth / 2f), gameAreaHeight / 2f, 0f);
                spawnRotation = Quaternion.Euler(0f, 0f, -90f); // Rotate -90 degrees on the z-axis
                transform.TransformVector(0, -Speed, 0);
                break;
            case 1: // Left border
                spawnPosition = new Vector3(-gameAreaWidth / 2f, Random.Range(-gameAreaHeight / 2f, gameAreaHeight / 2f), 0f);
                break;
            case 2: // Right border
                spawnPosition = new Vector3(gameAreaWidth / 2f, Random.Range(-gameAreaHeight / 2f, gameAreaHeight / 2f), 0f);
                spawnRotation = Quaternion.Euler(0f, 0f, 180f); // Rotate 180 degrees on the z-axis
                break;
        }

        GameObject enemyPrefab = enemyPrefabs[randomIndex];

        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, spawnRotation);

        //// instead of instantaite and create alot of bullets, make 20 bullets and active or inactive them then reuse them again
        //GameObject enemyInstance = ObjectPool.instance.getPooledObject();

        //if(enemyInstance != null)
        //{
        //    enemyInstance.transform.position = spawnPosition;
        //    enemyInstance.transform.rotation = spawnRotation;
        //    enemyInstance.SetActive(true);
        //}

        // If the enemy is spawned from the top or bottom border, make it move vertically
        if (randomBorder == 0)
        {
            // Attach a Rigidbody component to the enemy instance and set its velocity to move vertically
            Rigidbody2D rb = enemyInstance.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, -Speed); // Adjust the speed as needed
        }else if (randomBorder == 1)
        {
            // Attach a Rigidbody component to the enemy instance and set its velocity to move vertically
            Rigidbody2D rb = enemyInstance.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(Speed, 0f); // Adjust the speed as 
        }else
        {
            // Attach a Rigidbody component to the enemy instance and set its velocity to move vertically
            Rigidbody2D rb = enemyInstance.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-Speed, 0f); // Adjust the speed as 
        }
        

        return enemyPrefab;
    }


    public float spawnInterval = 3f;
    private float timer = 0f;
    public float gameAreaWidth = 10f;
    public float gameAreaHeight = 5f;
    public player_script plmv;
    public int [] playerHealth;
    public float [] NewSpawnInterval;
    public float[] newSpeed;
    //public float spawnIntervalRate = 0.1f;
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
            GenerateRandomEnemy();
            timer = 0f;

            for (int i = 0; i < playerHealth.Length; i++)
            {
                if(plmv.health == playerHealth[i])
                {
                    spawnInterval = NewSpawnInterval[i];
                    Speed = newSpeed[i];
                    Debug.Log("health is "+ i);
                }
            }
            //if (timer12 > speedAt[0] && timer12 < speedAt[1])
            //{
            //    spawnInterval = 1.3f;
            //}
            //if (timer12 > speedAt[1])
            //{
            //    spawnInterval = 1f;
            //}
        }
    }  
}
   
