using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public player_script player;
    public GameObject[] h;

  
    // Update is called once per frame
    void Update()
    {
        if (player.health > 5)
        {
            player.health = 5;
        }
        if (player.health < 0)
        {
            player.health = 0;
        }
        health_lose();
        health_add();
    }
    public void DeactivateObjectByName(string objectNameToDeactivate)
    {
        GameObject objectToDeactivate = GameObject.Find(objectNameToDeactivate);
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object with name " + objectNameToDeactivate + " not found.");
        }
    }
    public void activateObjectByName(string objectNameToActivate)
    {
        GameObject objectToActivate = GameObject.Find(objectNameToActivate);
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Object with name " + objectNameToActivate + " not found.");
        }
    }
    void health_lose()
    {
        if (player.health == 0)
        {
            if (GameObject.Find("heart_1") != null)
            {
                DeactivateObjectByName("heart_1");
            }
            if (GameObject.Find("heart_2") != null)
            {
                DeactivateObjectByName("heart_2");
            }
            if (GameObject.Find("heart_3") != null)
            {
                DeactivateObjectByName("heart_3");
            }
            if (GameObject.Find("heart_4") != null)
            {
                DeactivateObjectByName("heart_4");
            }
            if (GameObject.Find("heart_5") != null)
            {
                DeactivateObjectByName("heart_5");
            }
        }
        if (player.health == 1)
        {
            if (GameObject.Find("heart_2") != null)
            {
                DeactivateObjectByName("heart_2");
            }
            if (GameObject.Find("heart_3") != null)
            {
                DeactivateObjectByName("heart_3");
            }
            if (GameObject.Find("heart_4") != null)
            {
                DeactivateObjectByName("heart_4");
            }
            if (GameObject.Find("heart_5") != null)
            {
                DeactivateObjectByName("heart_5");
            }
        }
        if (player.health == 2)
        {
            if (GameObject.Find("heart_3") != null)
            {
                DeactivateObjectByName("heart_3");
            }
            if (GameObject.Find("heart_4") != null)
            {
                DeactivateObjectByName("heart_4");
            }
            if (GameObject.Find("heart_5") != null)
            {
                DeactivateObjectByName("heart_5");
            }
        }
        if (player.health == 3)
        {
            if (GameObject.Find("heart_4") != null)
            {
                DeactivateObjectByName("heart_4");
            }
            if (GameObject.Find("heart_5") != null)
            {
                DeactivateObjectByName("heart_5");
            }
        }
        if (player.health == 4)
        {
            if (GameObject.Find("heart_5") != null)
            {
                DeactivateObjectByName("heart_5");
            }
        }
    }
    void health_add()
    {
        if (player.health == 5)
        {
            h[4].SetActive(true);
        }
        if (player.health == 4)
        {
            if (h[3] != null)
            {
                h[3].SetActive(true);
            }
        }
        if (player.health == 3)
        {
            if (h[2] != null)
            {
                h[2].SetActive(true);
            }
        }
        if (player.health == 2)
        {
            if (h[1] != null)
            {
                h[1].SetActive(true);
            }
        }
        if (player.health == 1)
        {
            if (h[0] != null)
            {
                h[0].SetActive(true);
            }
        }
    }
}
