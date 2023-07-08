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
}
