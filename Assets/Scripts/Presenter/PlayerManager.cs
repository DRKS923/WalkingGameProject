using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDataPersistence
{
    public static PlayerManager Instance;
    public int playerLevel;
    public int currentExp;
    public int targetExp;

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


    void Update()
    {
        targetExp = TargetExpCalc(playerLevel);
        if (currentExp >= targetExp)
        {
            Levelup();
        }
        
    }

    public void LoadData(GameData data)
    {
       playerLevel = data.level;
       currentExp = data.currentExp;
    }

    public void SaveData(GameData data)
    {
        data.level = playerLevel;
        data.currentExp = currentExp;
    }

    void Levelup()
    {
        playerLevel++;
        currentExp -= targetExp;
        targetExp = TargetExpCalc(playerLevel);
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
