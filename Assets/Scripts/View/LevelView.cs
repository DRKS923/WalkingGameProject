using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    public TMP_Text currentLevelText;
    public TMP_Text currentExpText;
    public TMP_Text targetExpText;
    public int currentLevel;
    public int currentExp;
    public int targetExp;

    
    void Update()
    {
        currentLevel = PlayerManager.Instance.GetComponent<PlayerManager>().PlayerLevel;
        currentExp = PlayerManager.Instance.GetComponent<PlayerManager>().CurrentExp;
        targetExp = PlayerManager.Instance.GetComponent<PlayerManager>().TargetExp;
        currentLevelText.text = "Level: " + currentLevel.ToString();
        currentExpText.text = "EXP: " + currentExp.ToString();
        targetExpText.text = "Next Level: " + targetExp.ToString();  
    }
}
