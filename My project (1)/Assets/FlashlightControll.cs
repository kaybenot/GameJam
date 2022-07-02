using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControll : MonoBehaviour
{
    public float flashlightIntensity;
    void OnTriggerEnter(Collider other)
    {
        FlashLightPlayerHandler flc = other.GetComponentInChildren<FlashLightPlayerHandler>();
        if(flc != null){
            flc.pushVolume();
        }
    }

    void OnTriggerExit(Collider other)
    {        
        FlashLightPlayerHandler flc = other.GetComponentInChildren<FlashLightPlayerHandler>();
        if(flc != null){
            flc.popVolume();
        }
    }
}
