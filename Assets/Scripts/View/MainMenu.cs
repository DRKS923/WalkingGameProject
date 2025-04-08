using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {
        // Load the options menu
    }

    public void ShareData()
    {
        // Share game data
    }

    public void OpenCredits()
    {
        // Load the credits scene
    }
}
