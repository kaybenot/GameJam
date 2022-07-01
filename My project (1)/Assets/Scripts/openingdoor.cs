using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingdoor : MonoBehaviour
{
    bool opened;
    int angle;
    
    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(opened && angle < 90)
        {
            transform.Rotate(1, 0, 0);
            angle++;
        }
    }

    void open()
    {
        opened = true;
    }
}
