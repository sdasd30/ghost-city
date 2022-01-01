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
    private IsFlickering myIsFlickering;
    private Light2D myLight; 
    // Start is called before the first frame update
    void Start()
    {
        myIsFlickering = gameObject.GetComponent<IsFlickering>();
        myLight = GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= flicker_time)
        {
            if (myLight.intensity > 0)
            {
                myLight.intensity = 0;
                flicker_time += OffInterval + Random.Range(-1 * RandomnessFactor, RandomnessFactor) + RandomnessOffset;
            }
            else
            {
                myLight.intensity = 1;
                flicker_time += OnInterval + Random.Range(-1 * RandomnessFactor, RandomnessFactor) + RandomnessOffset;
            }
            
        }
        
    }
}
