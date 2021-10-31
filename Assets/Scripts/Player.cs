using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float movementSpeed;
    //public GameObject camera;
    public GameObject playerObj;
    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    public int maxHealth;
    public int health;
    public HealthBar healthBar;
    private RaycastHit[] hits;
    private GameObject triggeringEnemy;
    public static bool ableToEscape;

    //Methods
    void Start() {
        health = maxHealth;
        ableToEscape = false;
    }

    void Update() {
        //Player facing mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition); //detectar on esta el cursor
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist)) 
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation= Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f*Time.deltaTime); //moviment absolut
            //transform.rotation= Quaternion.Slerp(transform.rotation, targetRotation, 7f*Time.deltaTime); //moviment respecte la camera
        }

        //apuntar als enemics
        if (Physics.Raycast(ray, out RaycastHit hit, 100)) //No detecta be quan hi ha pared entre enemy i player
        {
            if(hit.collider.tag == "Walls") {
                //Debug.Log("hola");        
            }
            
            if(hit.collider.tag == "Guard" || hit.collider.tag == "Worker") 
            {
                //Debug.Log("apuntant a Enemy");
                GameObject enemy = hit.transform.gameObject;
                enemy.GetComponentInChildren<Enemy>().ScareEnemy(); //activar barra por    
            }
        }
        //Player Movement
        if(Input.GetKey(KeyCode.W))
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movementSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.A))
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        if(Input.GetKey(KeyCode.S))
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - movementSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
            transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        //Shooting
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        //Health
        healthBar.SetHealth(health);

        //Player Death
        if(health < 0) 
        {
            Die();
        }
    }

    void Shoot() {
        Instantiate(bullet.transform, bulletSpawnPoint.transform.position, playerObj.transform.rotation); //perque la bala surti en la direccio del player(pistola)  
    }
    public void Die() {
        GameOverManager.dead = true;
    }

    //Treure movil i obrir porta caixa forta
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PortaCaixaForta") //player es troba zona porta caixa forta
        {
            CaixaFortaManager.openDoor = true;         
        }
        if(other.tag == "Worker") 
        {
            triggeringEnemy = other.gameObject; //posar enemy a la variable
            triggeringEnemy.GetComponent<ProgressBarEnemy>().playerTriggering = true;    
        }
        if(other.tag == "CaixaForta") //player es troba zona porta caixa forta
        {
            StealMoney.robantDiners = true;         
        }
        if(other.tag == "PortaSortida") //player es troba zona porta caixa forta
        {
            if(ableToEscape) 
            {
                GameOverManager.exitBanc = true;   
            }
                  
        }
        
    } 
    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "PortaCaixaForta") //quan player surt de la zona de la porta
        {
            CaixaFortaManager.openDoor = false; //la deixa de obrir         
        }
        if(other.tag == "Worker") 
        {
            triggeringEnemy = other.gameObject; //posar enemy a la variable
            triggeringEnemy.GetComponent<ProgressBarEnemy>().playerTriggering = false;    
        }
        if(other.tag == "CaixaForta") //player es troba zona porta caixa forta
        {
            StealMoney.robantDiners = false;        
        }
    }
}
