using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenuButtons;
    [SerializeField] GameObject OptionsMenuButtons;
    public void StartGame()
    {
        // Load the game scene
        //maybe add some effects?
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void OpenOptions()
    {
        // Load the options menu
        // no idea what to put here atm, probably sound control and deleting saves
        MainMenuButtons.SetActive(false);
        OptionsMenuButtons.SetActive(true);
    }

    public void CloseOptions()
    {
        MainMenuButtons.SetActive(true);
        OptionsMenuButtons.SetActive(false);
    }

    public void ShareData()
    {
        // Share game data
        // add the whole 
    }

    public void OpenCredits()
    {
        // Load the credits scene
    }
}
