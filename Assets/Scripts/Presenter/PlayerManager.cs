using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDataPersistence
{
    public static PlayerManager Instance;
    public int PlayerLevel { get; private set; }
    public int CurrentExp { get; private set; }
    public int TargetExp { get; private set; }
    public int StepCoins { get; private set; }

    [SerializeField] private AudioSource lvUp;

    public bool allowMusic = true;
    public bool allowSfx = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        
        lvUp = GetComponent<AudioSource>();
    }


    void Update()
    {
        TargetExp = TargetExpCalc(PlayerLevel);
        if (CurrentExp >= TargetExp)
        {
            Levelup();
        }
        
    }

    public void LoadData(GameData data)
    {
       PlayerLevel = data.level;
       CurrentExp = data.currentExp;
       StepCoins = data.StepCoins; 

       allowMusic = data.allowMusic;
       allowSfx = data.allowSfx;
    }

    public void SaveData(GameData data)
    {
        data.level = PlayerLevel;
        data.currentExp = CurrentExp;
        data.StepCoins = StepCoins;

        data.allowMusic = allowMusic;
        data.allowSfx = allowSfx;
    }

    void Levelup()
    {
        PlayerLevel++;
        CurrentExp -= TargetExp;
        TargetExp = TargetExpCalc(PlayerLevel);
        if (allowSfx && lvUp != null)
        {
            lvUp.Play();
        }
    }

    public void GetCoins() 
    {
        StepCoins++;
    } 

    public void AddExp(int exp)
    {
        CurrentExp += exp;
    }

    public int TargetExpCalc(int currentLevel)
    {
        int prevLevel = currentLevel - 1;
        int firstPass = 0;
        int secondPass = 0;
        int thirdPass = 0;


        firstPass += (int)Math.Floor(prevLevel + (300.0f * Math.Pow(2.0f, prevLevel / 7.0f)));
        secondPass = firstPass / 40;
        thirdPass = secondPass * 10;

        return thirdPass;
    }

}
