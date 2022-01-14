using System.Collections;
using UnityEngine;

public class LightDetect : MonoBehaviour
{
    bool lit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            lit = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            lit = true;
        }
    }
}
