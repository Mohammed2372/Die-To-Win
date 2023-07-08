using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collider"))
        {
            BoxCollider2D.enabled = false;
        }
    }
}
