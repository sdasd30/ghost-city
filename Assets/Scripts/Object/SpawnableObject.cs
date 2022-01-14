using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    Vector2 spawnPoint;

    bool respawnOnDeath = false;

    void Awake()
    {
        spawnPoint = transform.position;
    }

    public void HandleDeath()
    {
        if (respawnOnDeath)
        {
            transform.position = spawnPoint;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
