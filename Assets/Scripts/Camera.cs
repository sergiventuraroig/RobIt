using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Variables
    public Transform player;
    public float smooth = 0.3f;
    public float height;
    private Vector3 velocity = Vector3.zero;

    //Methods
    void Update() {
        Vector3 pos = new Vector3();
        
        pos.x = player.position.x;  // inicialitzem pos.x a la posició inicial del jugador
        pos.z = player.position.z - 18; // inicialitzem la altura ver visualitzar el jugador de lluny
        pos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
        //transform.position = new Vector3(pos.x, pos.y, pos.z);

    }

    
}
