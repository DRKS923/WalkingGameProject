using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGMManager : MonoBehaviour, IDataPersistence
{   
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource soundEffects;

    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip backgroundMusic;

    public bool allowMusic = true;
    [SerializeField] private bool isMusicPlaying = true;
    public bool allowSfx = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        SaveData();
        if (allowMusic)
        {
            if (!isMusicPlaying)
            {
                music.Play();
                isMusicPlaying = true;
            }
        }
        else
        {
            if (isMusicPlaying)
            {
                music.Stop();
                isMusicPlaying = false;
            }
        }
    }

    public void LoadData(GameData data)
    {
        allowMusic = data.allowMusic;
        allowSfx = data.allowSfx;
    }

    public void SaveData(GameData data)
    {
        data.allowSfx = allowSfx;
        data.allowMusic = allowMusic;
    }

    void PlaySound()
    {
        if (allowSfx)
        {
            soundEffects.Play();
        }
    }

}
