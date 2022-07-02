using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject worldOne;
    public GameObject worldTwo;
    public Sepia sepia;

    private bool used = false;

    public void changeWorlds()
    {
        worldOne.SetActive(!worldOne.activeSelf);
        worldTwo.SetActive(!worldTwo.activeSelf);
        sepia.EnableSepia();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!used)
        {
            used = true;
            BlackOut.blackOut();
            Invoke("changeWorlds", 1f);
        }
    }
}