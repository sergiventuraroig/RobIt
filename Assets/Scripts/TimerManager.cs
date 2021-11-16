using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Image fill;
    public GameObject timer;
    public Text timerText;
    public float maxSeconds;
    private float seconds;
    public static bool alarmaApretada;
    
    // Start is called before the first frame update
    void Start()
    {
        alarmaApretada = false;
        seconds = maxSeconds;
        timer.SetActive(false); 
         
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds >= 0)
        {
            seconds -= 1*Time.deltaTime;
            UpdateUI(seconds);
            if (seconds <= 0)
            {
                GameOverManager.police = true;
            }
        }
               
    }

    private void UpdateUI(float seconds) 
    {
        timerText.text = string.Format("{0:D2}:{1:D2}", (int)seconds/60, (int)seconds%60);
        fill.fillAmount = seconds/maxSeconds;
    }
}
