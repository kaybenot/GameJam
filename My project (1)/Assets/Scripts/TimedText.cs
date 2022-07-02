using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimedText : MonoBehaviour
{
    public List<string> cutsceneDialogs;
    public float timePerLine = 3f;
    float timer;
    int i = 0;

    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = cutsceneDialogs[i];
        timer = timePerLine;
        i++;
    }

    void Update()
    {
        if(i < cutsceneDialogs.Count)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                timer = timePerLine;
                text.text = cutsceneDialogs[i];
                i++;
            }
        }
        else
            Destroy(gameObject, timePerLine);
    }
}
