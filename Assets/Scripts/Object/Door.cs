using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    GameObject prompt;

    public Sprite closed;
    public Sprite open;

    public bool locked;

    bool inRange = false;

    void Start()
    {
        prompt = transform.GetChild(0).gameObject;

        prompt.SetActive(false);

        GetComponent<SpriteRenderer>().sprite = closed;

        if (!locked)
        {
            SetPrompt("Press --interact-- to open");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && inRange)
        {
            if (locked)
            {
                locked = false;

                SetPrompt("Press --interact-- to open");
            }

            else
            {
                if (GetComponent<SpriteRenderer>().sprite == closed)
                {
                    GetComponent<SpriteRenderer>().sprite = open;
                    GetComponent<Collider2D>().enabled = false;

                    SetPrompt("Press --interact-- to close");
                }

                else
                {
                    GetComponent<SpriteRenderer>().sprite = closed;
                    GetComponent<Collider2D>().enabled = true;

                    SetPrompt("Press --interact-- to open");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.SetActive(true);

            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.SetActive(false);

            inRange = false;
        }
    }

    void SetPrompt(string text)
    {
        prompt.transform.GetChild(0).GetComponent<Text>().text = text;
        prompt.transform.GetChild(0).GetComponent<AxisReplace>().Replace();
    }
}
