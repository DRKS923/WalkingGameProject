using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource music;
    void OnEnable()
    {
        if (PlayerManager.Instance.allowMusic)
        {
            music.Play();
        }
    }

    private void Update()
    {
        if (!music.isPlaying && PlayerManager.Instance.allowMusic)
        {
            music.Play();
        }
    }

    public void MusicToggle()
    {
        if (PlayerManager.Instance.allowMusic)
        {
            PlayerManager.Instance.allowMusic = false;
            music.Stop();
        }
        else if (!PlayerManager.Instance.allowMusic)
        {
            PlayerManager.Instance.allowMusic = true;
            music.Play();
        }
    }
}
