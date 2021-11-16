using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StealMoney : MonoBehaviour
{
    public static bool robantDiners;
    public TextMeshProUGUI moneyText;
    public float maxMoney;
    private float stolenMoney;
    public static int moneyPercentage;
    void Start()
    {
        stolenMoney = 0;
        robantDiners = false; 
        moneyText.enabled = false;  
        moneyPercentage = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        
        if(robantDiners && stolenMoney < maxMoney) {
            stolenMoney += 1*Time.deltaTime;
            
            moneyText.enabled = true; 
        }
        moneyPercentage = (int)(100*(stolenMoney/maxMoney));
        moneyText.text = "Stolen Money: " + moneyPercentage  + " %";
    }
}
