using System.Collections;
using System.Collections.Generic;
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


    // Update is called once per frame
    void Update()
    {

        horizontal_move = Input.GetAxisRaw("Horizontal") * run_speed;
        animator.SetBool("jump", false);
        animator.SetFloat("run" ,Mathf.Abs(horizontal_move) );


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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
            }
            if (randommm >= 2)
            {
                health--;
            }
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            int randommm = Random.Range(0, 5);
            Destroy(collision.gameObject);
            if (randommm < 4)
            {
                health++;
            }
            if (randommm >= 4)
            {
                health--;
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
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("health"))
        {
            health -= 2;
            Destroy(collision.gameObject);
        }
    }
}
