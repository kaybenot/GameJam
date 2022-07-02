using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    public GameObject grat;

    private static Image blackImage;
    private static bool blackingOut = false;
    private bool goingBack = false;
    private static bool pernament = false;

    public void end()
    {
        Application.Quit(0);
    }

    public static void blackOut()
    {
        blackingOut = true;
    }

    public static void blackOutPernament()
    {
        blackingOut = true;
        pernament = true;
    }

    void Start()
    {
        blackImage = GameObject.FindGameObjectWithTag("BlackOut").GetComponent<Image>();
    }

    private void Update()
    {
        if(blackingOut)
        {
            blackImage.color += new Color(0f, 0f, 0f, Time.deltaTime);
            if(blackImage.color.a >= 1f)
            {
                if(!pernament)
                    goingBack = true;
                else
                {
                    grat.SetActive(true);
                    Invoke("end", 3f);
                }
                blackingOut = false;
            }
        }
        else if(goingBack)
            blackImage.color -= new Color(0f, 0f, 0f, Time.deltaTime);
            if(blackImage.color.a <= 0f)
                goingBack = false;
    }
}
