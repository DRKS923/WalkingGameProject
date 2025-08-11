using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    public int currentExp;
    public int steps;
    public int StepCoins;
    public bool allowMusic;
    public bool allowSfx;

    public float enemyTimer;
    public int enemyLevel;
    public int enemyCycle;
    public Vector3 enemyPosition;
    public SerializableDictionary<string, bool> enemyStatus;

    public Vector3 eventPosition;
    public bool currentEventStatus;
    public bool canTalk;
    public string currentEventId;


    public GameData() 
    {
        this.level = 1;
        this.currentExp = 0;
        this.steps = 0;
        this.StepCoins = 0;
        this.allowMusic = true;
        this.allowSfx = true;

        this.enemyTimer = 300;
        this.enemyLevel = 0;
        this.enemyCycle = 1;
        this.enemyPosition = Vector3.zero;
        enemyStatus = new SerializableDictionary<string, bool>();

        this.eventPosition = Vector3.zero;
        this.currentEventStatus = false;
        this.canTalk = false;
        this.currentEventId = "";
        
    }
}
