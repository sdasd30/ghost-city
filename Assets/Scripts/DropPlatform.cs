using UnityEngine;

public class DropPlatform : MonoBehaviour
{
    Transform player;

    bool playerTouching = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (playerTouching && Input.GetKey(KeyCode.S))
        {
            UnsetCollider();

            playerTouching = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerTouching = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnsetCollider();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetCollider();
        }
    }

    void UnsetCollider()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    void SetCollider()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
    }
}
