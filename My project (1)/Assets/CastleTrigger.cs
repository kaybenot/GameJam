using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastleTrigger : MonoBehaviour
{
    private bool triggerActive = false;
    private bool toggleElements = true;
    public GameObject prompt;
    public GameObject[] uiElements;
    public CharacterController player;
    public TMP_Text textField;

    void OnGUI()
    {
        if(triggerActive)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                textField.text += e.keyCode;
            }
        }
    }

    void Update()
    {
        if(triggerActive)
        {
            prompt.SetActive(true);
            if(Input.GetButtonDown("Interact"))
            {
                Debug.Log("temp");
                for (int i = 0; i < uiElements.Length; i++)
                {
                    uiElements[i].SetActive(toggleElements);
                }
                toggleElements = !toggleElements;
                textField.text = "";
                player.enabled = toggleElements;
            }
        }
        else
        {
            prompt.SetActive(false);
        }
    }

    void OnTriggerEnter()
    {
       triggerActive = true;
    }

    void OnTriggerExit()
    {
        triggerActive = false;
    }
}
