using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        //maybe add some effects?
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {
        // Load the options menu
        // no idea what to put here atm, probably sound control and deleting saves
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
