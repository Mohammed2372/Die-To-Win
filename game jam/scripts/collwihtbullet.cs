using UnityEngine;

public class collwihtbullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet") || collision.gameObject.CompareTag("bullet red"))
        {
            Destroy(collision.gameObject);
        }
    }
}

