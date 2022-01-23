/*
 * Author: Isaac
 * Description: Replaces sample text for buttons in UI with the proper name
 */

using UnityEngine;
using UnityEngine.UI;

public class AxisReplace : MonoBehaviour
{
    void Start()
    {
        Replace();
    }

    public void Replace()
    {
        GetComponent<Text>().text = GetComponent<Text>().text.Replace("--interact--", GameObject.Find("Player").GetComponent<Player>().interactButton);
    }
}
