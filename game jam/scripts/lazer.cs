using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lazer : MonoBehaviour

{
    //prefabs
    public GameObject green_lazer;
    public GameObject red_lazer;
    public GameObject purple_lazer;

    private GameObject faded_lazer;

    //timers
    public float spawn_time = 5f ;
    private float lazer_shown_time = 3f;
    private float faded_shown_time = 0.5f;
    
    private float purple_time;

    //others
    private Transform transform;
    GameObject spawned;
    public int green_to_red_ratio = 5;
    [HideInInspector] public int rand;
    [HideInInspector] public bool green;

    void Start()
    {
        purple_time = lazer_shown_time - faded_shown_time;
       
        StartCoroutine(sp());
    }

    private void spawn_lazer(GameObject spawn_object , bool random)
    {
    
        spawned = Instantiate(spawn_object) as GameObject ;

        if (random)
        {
            spawned.transform.position = new Vector2(Random.Range(-8.1f, 8.1f), 0);
        }
        else
        { 
            spawned.transform.position = transform.position;
        }
    }

    private IEnumerator sp()
    {
        while(true) {

            rand = Random.Range(0, 9);

            if ( rand <= green_to_red_ratio - 1)
            {
                faded_lazer = green_lazer;
                green = true;
            }

            else
            {
                faded_lazer = red_lazer;
                green = false;
            }

            yield return new WaitForSeconds(spawn_time);
            spawn_lazer(faded_lazer, true);
            transform = spawned.transform;

            yield return new WaitForSeconds(faded_shown_time);
            Destroy(spawned);
            spawn_lazer(purple_lazer, false);

            yield return new WaitForSeconds(purple_time);
            Destroy(spawned);
        }
    }
}
