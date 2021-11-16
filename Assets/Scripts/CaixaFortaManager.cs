using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaixaFortaManager : MonoBehaviour
{
    public Image fill;
    public GameObject targetObject;
    public GameObject progressBar;
    public float secondsToOpen;
    private float seconds;
    public static bool openDoor;
    private static bool obrint;

    // Start is called before the first frame update
    void Start()
    {
        openDoor = false;
        obrint = false;
        seconds = 0; 
        progressBar.SetActive(false);        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            obrint = true;
        } 

        if(openDoor && obrint) //si player fa trigger al collider
        { 
            progressBar.SetActive(true); 
            seconds += 1*Time.deltaTime;
            fill.fillAmount = seconds/secondsToOpen;
            if(seconds >= secondsToOpen) //quant ha passat el temps
            {
                progressBar.SetActive(false);
                targetObject.SetActive(false);
            }
        }
        else {
            obrint = false; // per haver de clicar space si es surt de la porta
        }               
    }
}
