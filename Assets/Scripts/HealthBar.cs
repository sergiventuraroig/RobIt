using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private Quaternion rotation;

    void Awake() 
    {
        rotation = transform.rotation;
    }

     void LateUpdate () 
     {
        transform.rotation = rotation;    
     }

    public void SetHealth(int health)
    {
        fill.color = gradient.Evaluate(slider.normalizedValue); // para que health color entre 0 y 1
        slider.value = health;
    }

}
