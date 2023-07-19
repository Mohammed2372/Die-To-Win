using UnityEngine;

public class AvoidCollision : MonoBehaviour
{
    private PolygonCollider2D objectCollider;

    private void Start()
    {
        objectCollider = GetComponent<PolygonCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //        Debug.Log("enter");
    //    // Disable the object's collider when it collides with another object
    //    if (collision.gameObject.CompareTag("collider")){
    //        objectCollider.isTrigger = true;
    //        Debug.Log("if");
    //    }
    //        objectCollider.isTrigger = true;
    //        Debug.Log("not");

    //}
    ////solution for the collission of bullets with platforms to make a spawner for right bullets and different
    ////spawner for left bullet to make each bullet move with specifice velocit after collide with platform,
    ////but the problem is there are two spawner for two bullets red and green it will be like four different
    ////spawner with two scirpts from right and left
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    // Enable the object's collider when it is no longer colliding with another object
    //    objectCollider.isTrigger = false;
    //        Debug.Log("out");

    //}
}

