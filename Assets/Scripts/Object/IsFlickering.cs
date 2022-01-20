using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class IsFlickering : MonoBehaviour
{
    public float RandomnessFactor;
    public float OnInterval;
    public float OffInterval;
    public float RandomnessOffset;
    private float flicker_time;
    private bool on;
    private IsFlickering myIsFlickering;
    private Light2D[] myLights; 
    // Start is called before the first frame update
    void Start()
    {
        myIsFlickering = gameObject.GetComponent<IsFlickering>();
        myLights = GetComponentsInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        on = myLights[0].intensity != 0;
        if (Time.time >= flicker_time)
        {
            if (on)
            {
                foreach (Light2D l in myLights)
                {
                    l.intensity = 0;
                    flicker_time += OffInterval + Random.Range(-1 * RandomnessFactor, RandomnessFactor) + RandomnessOffset;
                }
            }
            else
            {
                foreach (Light2D l in myLights)
                {
                    l.intensity = 1;
                    flicker_time += OnInterval + Random.Range(-1 * RandomnessFactor, RandomnessFactor) + RandomnessOffset;
                }
            }
        }
    }
}