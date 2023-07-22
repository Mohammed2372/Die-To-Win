using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_script : MonoBehaviour
{

    public CharacterController2D controller;
    [HideInInspector] public float horizontal_move = 0f;
    public float run_speed = 40f;
    private bool jump = false;
    public Animator animator;
    [HideInInspector] public int health = 5;
    [HideInInspector] public float timer12 = 0;
    public  float wintimer;
    public TextMeshProUGUI score_text;
    int rt;
    public int score;

    public AudioSource jumps, hits, hps;

    public Button jump_button;
    // Update is called once per frame

    public void Jump()
    {
        jump = true;
        jumps.Play();
        animator.SetBool("jump" , true);
    }
    public void moveright()
    {
        horizontal_move = 1f * run_speed;
    }
    public void moveleft()
    {
        horizontal_move = -1f * run_speed;
    }
    void Update()
    {


        //horizontal_move = Input.GetAxisRaw("Horizontal") * run_speed;


        
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveleft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveright();
        }
        else
        {
            horizontal_move = 0;
        }

        animator.SetBool("jump", false);
        animator.SetFloat("run" ,Mathf.Abs(horizontal_move) );

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (health <= 0)
        {
            die();
        }

        if(SceneManager.GetActiveScene().name == "Game")
        {
            timer12 += Time.deltaTime;
        }

        rt = (int)timer12 * 20;
        rt = 3000 - rt;
        score = rt;
        //score_text.text = rt.ToString();
        if(timer12 > 135)

        {
            SceneManager.LoadScene("lose");
        }
    }

    private void FixedUpdate()
    {
       
        controller.Move(horizontal_move * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            int randommm = Random.Range(0, 4);
            Destroy(collision.gameObject);
            if (randommm < 2)
            {
                hps.Play();
            }
            if (randommm >= 2)
            {
                health--;
                hits.Play();
            }
        }

        /*
        if (collision.gameObject.CompareTag("bullet"))
        {
            int randommm = Random.Range(0, 5);
            Destroy(collision.gameObject);
            if (timer12 > 60)
            {
                if (randommm < 3)
                {
                    health++;
                    hps.Play();
                }
                if (randommm >= 3)
                {
                    health--;
                    hits.Play();
                }
            }
            else if (timer12 > 120)
            {
                if (randommm < 2)
                {
                    health++;
                    hps.Play();
                }
                if (randommm >= 2)
                {
                    health--;
                    hits.Play();
                }
            }
            else
            {
                if (randommm < 4)
                {
                    health++;
                    hps.Play();
                }
                if (randommm >= 4)
                {
                    health--;
                    hits.Play();
                }
            }
        }
        */
        if (collision.gameObject.CompareTag("lazerg"))
        {
            health++;
        }
        if (collision.gameObject.CompareTag("lazerr"))
        {
            health--;
        }
        if (collision.gameObject.CompareTag("poison"))
        {
            health++;
            hps.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("health"))
        {
            health -= 2;
            hits.Play();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            hits.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("bullet red"))
        {
            health++;
            hps.Play();
            Destroy(collision.gameObject);
        }
    }
    void die()
    {
        wintimer = timer12;
        PlayerPrefs.SetFloat("time", wintimer);  
        SceneManager.LoadScene("win");
    }
}
