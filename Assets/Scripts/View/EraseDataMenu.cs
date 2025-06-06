using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EraseDataMenu : MonoBehaviour, IDataPersistence
{
    [SerializeField] GameObject EraseDataMenuPanel;
    [SerializeField] GameObject OptionsMenuPanel;
    [SerializeField] GameObject ConfirmationPanel;

    public TMP_text stepCount;  
    public TMP_text playerLevel;

    private float stepCountValue;
    private int playerLevelValue;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        stepcountValue = data.stepCount;
        playerLevelValue = data.playerLevel;
    }
    public void SaveData(GameData data)
    {
        //No Need for this one
    }

    public void EraseDataButton()
    {
        // Open the confirmation panel
        EraseDataMenuPanel.SetActive(false);
        ConfirmationPanel.SetActive(true);
    }

    public void ReturnToOptionsButton()
    {
        // Return to the options menu
        EraseDataMenuPanel.SetActive(false);
        OptionsMenuPanel.SetActive(true);
    }

    public void ConfirmEraseDataButton()
    {
        // Confirm data erasure
        // Implement the logic to erase game data here
        Debug.Log("Game data erased.");
        // After erasing, return to the options menu or main menu
        ConfirmationPanel.SetActive(false);
        OptionsMenuPanel.SetActive(true);
    }

    public void CancelEraseDataButton()
    {
        // Cancel the erase data action
        ConfirmationPanel.SetActive(false);
        EraseDataMenuPanel.SetActive(true);
    }

    void ShowData()
    {
        if(OptionsMenuPanel.activeSelf)
        {
            // Display the current step count and player level in the UI
            stepCount.text = "Step Count: " + stepCountValue.ToString();
            playerLevel.text = "Player Level: " + playerLevelValue.ToString();
        }
        
    }



}
