using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    public int currentExp;
    public int steps;

    public GameData() 
    {
        this.level = 1;
        this.currentExp = 0;
        this.steps = 0;
    }
}
