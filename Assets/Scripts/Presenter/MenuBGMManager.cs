using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGMManager : MonoBehaviour, IDataPersistence
{    
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource soundEffects;

    public bool allowMusic = true;
    [SerializeField] private bool isMusicPlaying = false;
    public bool allowSfx = true;

    public static MenuBGMManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
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

    public void MusicToggle()
    {
        if (allowMusic)
        {
            allowMusic = false;
        }
        else if (!allowMusic)
        {
            allowMusic = true;
        }
    }

    public void SoundToggle()
    {
        if (allowSfx)
        {
            allowSfx = false;
        }
        else if (!allowSfx)
        {
            allowSfx = true;
            PlaySound();
        }
    }
}
