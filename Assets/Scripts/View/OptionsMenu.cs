using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    

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

    }
}
