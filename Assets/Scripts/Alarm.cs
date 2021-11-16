using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public GameObject Timer;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Worker") 
        {
            TimerManager.alarmaApretada = true;
            //TimerManager.alarmPressed = true;
            Player.ableToEscape = true;   
            Timer.SetActive(true);  
        }
    }    
}
