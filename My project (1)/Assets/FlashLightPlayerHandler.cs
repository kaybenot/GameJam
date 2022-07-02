using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPlayerHandler : MonoBehaviour
{
    public int volumeCount = 0;
    public float flashlightIntensity = 200.0f;
    public Light flashlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(volumeCount > 0)
        {
            flashlight.intensity = flashlightIntensity;
        }
        else
        {
            flashlight.intensity = 0.0f;
        }
    }

    public void pushVolume()
    {
        volumeCount ++;
    }

    public void popVolume()
    {
        volumeCount --;
    }
}
