using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerLevel : MonoBehaviour, IDataPersistence
{
    public int playerLevel;
    public int currentExp;
    public int targetExp;
    
    void Update()
    {
        if (currentExp >= targetExp)
        {
            playerLevel++;
            currentExp -= targetExp;
            targetExp += 50;
        }
    }

    public void LoadData(GameData data)
    {
       playerLevel = data.level;
       currentExp = data.currentExp;
       targetExp = data.targetExp;
    }

    public void SaveData(GameData data)
    {
        data.level = playerLevel;
        data.currentExp = currentExp;
        data.targetExp = targetExp;
    }
    
}
