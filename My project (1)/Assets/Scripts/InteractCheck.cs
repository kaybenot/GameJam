using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCheck : MonoBehaviour
{
    public GameObject message;
    public Sepia sepia;
    
    private bool reacting = false;

    private void OnTriggerEnter(Collider collider)
    {
        reacting = true;
        message.SetActive(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        reacting = false;
        message.SetActive(false);
    }

    private void Update()
    {
        if(reacting)
        {
            if(Input.GetKey("Interact"))
            {
                BlackOut.blackOut();
                sepia.DisableSepia();
                Destroy(transform);
            }
        }
    }
}
