using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject EraseDataMenu;
    [SerializeField] GameObject OptionsMenuPanel;

    public void MusicToggleButton()
    {
        MenuBGMManager.Instance.MusicToggle();
    }

    public void SoundToggleButton()
    {
        MenuBGMManager.Instance.SoundToggle();
    }

    public void OpenEraseDataMenu()
    {
        // Open the erase data menu
        OptionsMenuPanel.SetActive(false);
        EraseDataMenu.SetActive(true);
    }
}
