using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    private static Image blackImage;
    private static bool blackingOut = false;
    private bool goingBack = false;

    public static void blackOut()
    {
        blackingOut = true;
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
                goingBack = true;
                blackingOut = false;
            }
        }
        else if(goingBack)
            blackImage.color -= new Color(0f, 0f, 0f, Time.deltaTime);
            if(blackImage.color.a <= 0f)
                goingBack = false;
    }
}
