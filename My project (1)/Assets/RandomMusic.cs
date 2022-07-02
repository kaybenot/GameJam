using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicSource;

    void Start()
    {
        Invoke("self_play",60.0f);
    }

    void self_play()
    {
        musicSource.Play();
        Invoke("self_play",180.0f);
    }
}
