using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource music;
    public bool isPlaying = true;
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }
    
    public void MusicToggle()
    {
        if (isPlaying)
        {
            isPlaying = false;
            music.Stop();
        }
        else if (!isPlaying)
        {
            isPlaying = true;
            music.Play();
        }
    }
}
