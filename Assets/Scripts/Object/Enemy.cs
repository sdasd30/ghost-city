/*
 * Author: Isaac
 * Description: Controls enemy prefab
 */

using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;

    Rigidbody2D rbd;

    float distance = 2;
    float maxSpeed = 0.75f;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        rbd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 toPlayer = player.position - transform.position;

        if (toPlayer.magnitude > distance)
        {
            rbd.AddForce(toPlayer);
        }

        if (rbd.velocity.magnitude > maxSpeed)
        {
            rbd.velocity = rbd.velocity.normalized * maxSpeed;
        }
    }
}
