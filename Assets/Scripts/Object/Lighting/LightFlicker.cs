/*
 * Author: Vincent, Daniel
 * Description: Flickering lights on and off. Can be soft or harsh.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] private bool harshFlicker;
    [SerializeField] private float timeVariation;
    [SerializeField] private float onInterval;
    [SerializeField] private float offInterval;
    [SerializeField] private float minLight;
    [SerializeField] private float maxLight;

    private float flickerCool;
    private float timeToCool; //For soft flicker only.
    private bool rising; //For soft flicker only.
    private Light2D myLight; 
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponentInChildren<Light2D>();
        myLight.intensity = minLight;
    }

    // Update is called once per frame
    void Update()
    {
        if (float.IsInfinity(myLight.intensity))
        {
            myLight.intensity = minLight;
            rising = true;
        }

        if (harshFlicker)
        {
            if (flickerCool < 0)
            {
                if (myLight.intensity == maxLight)
                {
                    myLight.intensity = minLight;
                    flickerCool = offInterval + Random.Range(-1 * timeVariation, timeVariation);
                }
                else
                {
                    myLight.intensity = maxLight;
                    flickerCool = onInterval + Random.Range(-1 * timeVariation, timeVariation);
                }

            }
            flickerCool -= Time.deltaTime;
        }

        else
        {
            if (rising)
            {
                myLight.intensity += ((maxLight - minLight) * Time.deltaTime) / timeToCool ;
                if (myLight.intensity >= maxLight)
                {
                    rising = false;
                    flickerCool = offInterval + Random.Range(-1 * timeVariation, timeVariation);
                    timeToCool = flickerCool;
                }
            }
            else
            {
                myLight.intensity -= ((maxLight - minLight) * Time.deltaTime) / timeToCool;
                if (flickerCool < 0)
                { 
                    rising = true;
                    flickerCool = offInterval + Random.Range(-1 * timeVariation, timeVariation);
                    timeToCool = flickerCool;
                }
            }
            flickerCool -= Time.deltaTime;
        }
    }
}
