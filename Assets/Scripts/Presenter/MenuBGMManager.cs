using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGMManager : MonoBehaviour, IDataPersistence
{   
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource soundEffects;

    [SerializeField] private bool allowMusic = true;
    [SerializeField] private bool isMusicPlaying = true;
    [SerializeField] private bool allowSfx = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {
        
    }

    void PlaySound(){

    }

    void PlayMusic(){
        
    }

}
