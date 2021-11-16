using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarEnemy : MonoBehaviour
{
    //proggressBar
    public Image fill;
    public GameObject targetObject;
    public GameObject progressBar;
    public float secondsToOpen;
    private float seconds;
    public bool playerTriggering;
    private bool startRemoving; 
    private Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;  
        progressBar.SetActive(false); 
        playerTriggering = false; 
        startRemoving = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            startRemoving = true;
        } 
        
        if(playerTriggering && startRemoving) //si player fa trigger al collider
        { 
            progressBar.SetActive(true); 
            seconds += 1*Time.deltaTime;
            fill.fillAmount = seconds/secondsToOpen;
            if(seconds >= secondsToOpen) //quant ha passat el temps
            {
                progressBar.SetActive(false);
                targetObject.SetActive(false);
                this.GetComponent<EnemyAI>().hasObject = false;
            }
        } 
        else {
            startRemoving = false; // evita que es resumeixi sense apretar space 
        }   
    }
    void LateUpdate() {
        progressBar.transform.rotation = rotation;       
    }
}
