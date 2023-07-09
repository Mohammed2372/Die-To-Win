using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{

    public CharacterController2D controller;
    private float horizontal_move = 0f;
    public float run_speed = 40f;
    private bool jump = false;
    public Animator animator;
    [HideInInspector] public int health = 5;
    [HideInInspector] public float timer12 = 0;
    public TextMeshProUGUI score_text;
    int rt;
    public int score;

    public AudioSource jumps, hits, hps;
    // Update is called once per frame
    void Update()
    {


        horizontal_move = Input.GetAxisRaw("Horizontal") * run_speed;
        animator.SetBool("jump", false);
        animator.SetFloat("run" ,Mathf.Abs(horizontal_move) );


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            jumps.Play();
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
        animator.SetBool("jump" , true);
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
    void die()
    {
        SceneManager.LoadScene("win");
    }
}
