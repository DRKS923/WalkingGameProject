using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private int currentPage;
    [SerializeField]private GameObject menu;
    [SerializeField]private GameObject bgmManager;
    [SerializeField] private GameObject gameUI;
    [SerializeField]private List<GameObject> pages = new();

    void Start()
    {

    }

    public void OpenClose()
    {
        if (!StepCounter.Instance.isMenuOpen)
        {
            menu.SetActive(true);
            gameUI.SetActive(false);
            StepCounter.Instance.isMenuOpen = true;
        }
        else if (StepCounter.Instance.isMenuOpen)
        {
            menu.SetActive(false);
            gameUI.SetActive(true);
            StepCounter.Instance.isMenuOpen = false;
        }
    }

    public void ToMainMenu()
    {
        //save data then change scene to main menu
    }

    public void ToggleMusic()
    {
        bgmManager.GetComponent<BGMManager>().MusicToggle();
    }

    public void ToggleSFX()
    {
        if (!PlayerManager.Instance.allowSfx)
        {
            PlayerManager.Instance.allowSfx = true;
        }
        else if (PlayerManager.Instance.allowSfx)
        {
            PlayerManager.Instance.allowSfx = false;
        }
    }

    public void ToggleInstructions()
    {
        currentPage = 0;
        pages[currentPage].SetActive(true);
    }

    public void ClosePage()
    {
        pages[currentPage].SetActive(false);
    }
    public void NextPage()
    {
        pages[currentPage].SetActive(false);
        currentPage++;
        if (currentPage < pages.Count)
        {
            pages[currentPage].SetActive(true);
        }
    }
}
