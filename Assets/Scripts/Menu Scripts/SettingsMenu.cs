using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown graphicsDropdown;
    public GameObject settingsPanel;
    
    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume); 
        //audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); //ya que los db no son lineales       
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        //graphicsDropdown.RefreshShownValue();
    } 

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
    public void ExitPanel() {
        settingsPanel.SetActive(false);
    }
}
