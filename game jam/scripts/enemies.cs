using UnityEngine;
using UnityEngine.SceneManagement;

public class enemies : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    //public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform playerTransform;
    public player_script plmv;

    public EnemyState currentState = EnemyState.Idle;

    public float moveSpeed = 2.0f;
    public float startAt = 0;
    public float endAt = 0;
    public float TimeToWait = 2;
    public float attackRange = 1.0f;
    
    float temptime;
    float timer12 = 0f;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        temptime = 0;
        timer12 = 0;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            timer12 += Time.deltaTime;
        }

        if (timer12 > startAt)
        {
            temptime += Time.deltaTime;

            switch (currentState)
            {
                case EnemyState.Idle:
                    Idle();
                    break;
                case EnemyState.Chase:
                    if (temptime > TimeToWait)
                    {
                        Chase();
                    }
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
            }
        }
        if(timer12 > endAt)
        {
            gameObject.SetActive(false);
        }
    }
    private void Idle()
    {
        //animartion
        //animator.SetBool("idle", true);
        //animator.SetBool("attack", false);
        //animator.SetBool("run", false);

        //transition to chase
        currentState = EnemyState.Chase;
    }

    private void Chase()
    {
        //animation
        //animator.SetBool("run", true);
        //animator.SetBool("idle", false);
        //animator.SetBool("attack", false);

        //transfrom flip X
        if (Vector3.Distance(playerTransform.position, transform.position) > 0.01f)
        {
            if (playerTransform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        //moving
        Vector2 direction = playerTransform.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

        //attacking
        if (Vector2.Distance(transform.position, playerTransform.position) < attackRange)
        {
            currentState = EnemyState.Attack;
        }
    }
    private void Attack()
    {
        // Stop moving
        transform.Translate(Vector2.zero);

        //animation
        //animator.SetBool("attack", true);
        //animator.SetBool("idle",false);
        //animator.SetBool("run",false);

        // Attack the player
        plmv.health += 2;

        //reset
        temptime = 0;
        
        // Transition back to chase state
        currentState = EnemyState.Idle;
    }     
}