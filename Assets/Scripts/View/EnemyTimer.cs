using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


public class EnemyTimer : MonoBehaviour
{
    [SerializeField]private TMP_Text counterNumberText;
    private string displayNumber;
    
    void Update()
    {
        if(EnemyManager.Instance.GetComponent<EnemyManager>().spawnTimer > 0)
        {
            displayNumber = FormatTime(EnemyManager.Instance.GetComponent<EnemyManager>().spawnTimer);
            counterNumberText.text = displayNumber;
        }
        else
        {
            counterNumberText.text = "Incoming";
        }
        
        
        
    }

    string FormatTime(float timer)
    {
        TimeSpan interval = TimeSpan.FromSeconds(timer);
        string convertedTime = interval.ToString(@"mm\:ss");
        return convertedTime;
    }

}
