using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    public GameObject playerCharacter;
    public PlayerLevel playerLevel;
    public TMP_Text currentLevelText;
    public TMP_Text currentExpText;
    public TMP_Text targetExpText;
    public int currentLevel;
    public int currentExp;
    public int targetExp;
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        playerLevel = playerCharacter.GetComponent<PlayerLevel>();
    }

    
    void Update()
    {
        currentLevel = playerLevel.playerLevel;
        currentExp = playerLevel.currentExp;
        targetExp = playerLevel.targetExp;
        currentLevelText.text = "Level: " + currentLevel.ToString();
        currentExpText.text = "EXP: " + currentExp.ToString();
        targetExpText.text = "Next Level: " + targetExp.ToString();  
    }
}
