using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaryBar : MonoBehaviour
{
    public float maxTime;
    private float currentTime;
    public Image Fill;
    public Text barText;
    public GameObject scaryBar;
    private Quaternion rotation;
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        SetMaxTime();
        scaryBar.SetActive(false);
        //currentTime = 30;
        rotation = transform.rotation;       
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0) {
            //scaryBar.SetActive(true);
            currentTime -= 1*Time.deltaTime;
            UpdateBar();  
        }
        else {
            enemy.GetComponentInChildren<EnemyAI>().currentState.GoToStandardState();
            //this.enabled = false;
            scaryBar.SetActive(false);
            //barText.enabled = false; //no el canvio a true mai de moment
        }      
    }
    void LateUpdate () 
    {
        transform.rotation = rotation;    
    }

    public void SetMaxTime() 
    {
        currentTime = maxTime;
    }
    public void UpdateBar() 
    {
        barText.text = ((int)currentTime).ToString();
        Fill.fillAmount = currentTime/maxTime;
    }
}
