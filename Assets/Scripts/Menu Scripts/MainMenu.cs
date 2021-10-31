using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public void NewGame() 
    {
        SceneManager.LoadScene("Bank1");
    }
    public void EnablePanel() {
        settingsPanel.SetActive(true);
    }
}
