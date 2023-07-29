
using TMPro;
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
    public float wintimer;
    public float gameTime = 0f;
    public TextMeshProUGUI score_text;
    int rt;
    public int score;

    public AudioSource jumps, hits, hps;

    public Button jump_button;

    public Joystick joystick;
    
    // Update is called once per frame

    public void Jump(bool jumpb)
    {
        if (jumpb)
        {
            jump = true;
            jumps.Play();
            animator.SetBool("jump", true);
        }
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

        //// moving with joystick
        //horizontal_move = joystick.Horizontal * run_speed;
        if (joystick.Horizontal >= .3f) // to make it less sensitive
        {
            horizontal_move = run_speed;
        }
        else if (joystick.Horizontal <= -.3f)
        {
            horizontal_move = -run_speed;
        }
        else
        {
            horizontal_move = 0f;
        }

        //// moving with keyboard
        //horizontal_move = Input.GetAxisRaw("Horizontal") * run_speed; // in joystick hide this line, in windows version just uncomment it

        //if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    moveleft();
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    moveright();
        //}
        //else
        //{
        //    horizontal_move = 0;
        //}

        animator.SetBool("jump", false);
        animator.SetFloat("run" ,Mathf.Abs(horizontal_move) );

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump(true); // if i want to make the joystick jump, just add (verticalmove >= .5f);
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
        ////score_text.text = rt.ToString();
        if(timer12 > gameTime)
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
            health++;
            hps.Play();
            Destroy(collision.gameObject);
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
            health --;
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
        if (collision.gameObject.CompareTag("saw"))
        {
            Destroy(collision.gameObject);
            health--;
            hits.Play();
        }
        if (collision.gameObject.CompareTag("monster"))
        {
            hps.Play();
        }
        
    }
    void die()
    {
        wintimer = timer12;
        PlayerPrefs.SetFloat("time", wintimer);  
        SceneManager.LoadScene("win");
    }
}
