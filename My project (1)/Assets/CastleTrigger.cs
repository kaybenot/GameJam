using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastleTrigger : MonoBehaviour
{
    private bool triggerActive = false;
    private bool toggleElements = true;
    public GameObject prompt;
    public GameObject passGUI;
    public CharacterController player;
    public TMP_Text textField;
    public GameObject enterText;

    private string buff;

    void OnGUI()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            buff += Event.current.keyCode;
        }
    }

    public void FinishGame()
    {
        BlackOut.blackOutPernament();
    }

    void Update()
    {
        if(triggerActive)
        {
            if(Input.GetButtonDown("Submit"))
            {
                if(textField.text != "AST")
                {
                    prompt.SetActive(false);
                    textField.text = "";
                    buff = "";
                }
                else
                {
                    passGUI.SetActive(false);
                    enterText.SetActive(false);
                    prompt.SetActive(false);
                    FinishGame();
                    triggerActive = false;
                }
            }
            else if(Input.GetButtonDown("Interact"))
            {
                prompt.SetActive(!prompt.activeSelf);
                enterText.SetActive(!enterText.activeSelf);
                passGUI.SetActive(!passGUI.activeSelf);
                toggleElements = !toggleElements;
                textField.text = "";
                player.enabled = toggleElements;
                buff = "";
            }
            else if(passGUI.activeSelf)
            {
                if(buff.Length > 0)
                    textField.text += buff[0];
                buff = "";
            }
        }
    }

    void OnTriggerEnter()
    {
       triggerActive = true;
       prompt.SetActive(true);
    }

    void OnTriggerExit()
    {
        triggerActive = false;
        prompt.SetActive(false);
    }
}
