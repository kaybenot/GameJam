using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControll : MonoBehaviour
{
    public float flashlightIntensity;
    void OnTriggerEnter(Collider other)
    {
        Light ll = other.GetComponentInChildren<Light>();
        if(ll != null)
        {
            ll.intensity = flashlightIntensity;
        }
    }

    void OnTriggerExit(Collider other)
    {        
        Light ll = other.GetComponentInChildren<Light>();
        if(ll != null)
        {
            ll.intensity = 0.0f;
        }
    }
}
