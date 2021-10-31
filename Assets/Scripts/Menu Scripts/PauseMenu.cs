using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; //utilitzar per apagar audios quan es pagi pause
    public GameObject pauseMenuPanel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameIsPaused) {
                Resume();
            }
            else{
                Pause();
            }
        }  
    }
    public void Resume() 
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void GoMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
