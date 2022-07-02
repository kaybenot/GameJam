using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Album : MonoBehaviour
{
    public GameObject album;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Album"))
        {
            album.SetActive(!album.activeSelf);
        }
    }
}
