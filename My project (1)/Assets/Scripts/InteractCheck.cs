using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCheck : MonoBehaviour
{
    public GameObject message;
    public Sepia sepia;
    public Teleport teleport;
    
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
            if(Input.GetButtonDown("Interact"))
            {
                BlackOut.blackOut();
                OnTriggerExit(new Collider());
                sepia.Invoke("DisableSepia", 1f);
                teleport.Invoke("changeWorlds", 1f);
                Destroy(gameObject);
            }
        }
    }
}
