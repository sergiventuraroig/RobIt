using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float maxTime;
    private float currentTime = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("MainMenu");    
        }

        if (currentTime >= maxTime)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else 
        {
            currentTime += 1*Time.deltaTime;
        }
    }
}
