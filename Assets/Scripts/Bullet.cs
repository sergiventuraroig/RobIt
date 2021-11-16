using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variables
    public float bulletSpeed; 
    public float maxDistance;
    private GameObject triggeringEnemy;
    public int damage;
    private GameObject player;

    //Methods 
    void Start() 
    {
        player = GameObject.FindWithTag("Player"); //vigilar si hi ha més d'un jugador
    } 
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed); //perque la bala viatgi
        maxDistance += 1 * Time.deltaTime;   

        if(maxDistance >= 5) //Destruir la bala un cop passen 5 segons
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Guard" || other.tag == "Worker") 
        {
            triggeringEnemy = other.gameObject; //posar enemy a la variable
            triggeringEnemy.GetComponent<EnemyAI>().health -= damage; //treureli vida
            //canviar a boolean die i que no faci res pero es quedi el cos  
            Destroy(this.gameObject); //destruir la bala al colisionar  
        }
        else if(other.tag == "Player")
        {
            player.GetComponent<Player>().health -= damage; 
            //Debug.Log(player.GetComponent<Player>().health);
            Destroy(this.gameObject); //destruir la bala al colisionar    
        }
        else if(other.tag == "Walls")
        {
            Destroy(this.gameObject); //destruir la bala al colisionar    
        }
    }
}
