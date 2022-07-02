using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sepia : MonoBehaviour
{
    public GameObject globalVolume;
    
    public void EnableSepia()
    {
        globalVolume.SetActive(true);
    }

    public void DisableSepia()
    {
        globalVolume.SetActive(false);
    }
}
