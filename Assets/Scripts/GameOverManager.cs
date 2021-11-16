using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI deadText;
    public TextMeshProUGUI policeText;
    public TextMeshProUGUI exitText;
    public float waitTime;
    private float currentTime;
    public static bool dead;
    public static bool police;
    public static bool exitBanc;
    void Start()
    {
        deadText.enabled = false;  
        policeText.enabled = false; 
        exitText.enabled = false;
        currentTime = 0;
        dead = false;
        police = false; 
        exitBanc = false; 
    }

    // Update is called once per frame
    void Update() {
        if (dead || police || exitBanc) {
            if (currentTime < waitTime) {
                currentTime += 1*Time.deltaTime;
            }
            else {
                SceneManager.LoadScene("MainMenu");    
            }
        }
        if(dead) 
        {
            deadText.enabled = true;   
        }
        else if(police)
        {
            policeText.enabled = true;    
        }
        if(exitBanc) 
        {
            exitText.enabled = true;
            exitText.text = "Congratulations, you Robbed " + StealMoney.moneyPercentage + " % of the money!";
        }
    }
}
