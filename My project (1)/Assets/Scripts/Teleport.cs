using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject worldOne;
    public GameObject worldTwo;

    private bool used = false;

    IEnumerator changeWorlds()
    {
        worldOne.SetActive(!worldOne.activeSelf);
        worldTwo.SetActive(!worldTwo.activeSelf);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!used)
        {
            Debug.Log("asd");
            used = true;
            StartCoroutine(changeWorlds());
        }
    }
}