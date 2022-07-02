using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject worldOne;
    public GameObject worldTwo;

    private bool used = false;

    public void changeWorlds()
    {
        worldOne.SetActive(!worldOne.activeSelf);
        worldTwo.SetActive(!worldTwo.activeSelf);
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