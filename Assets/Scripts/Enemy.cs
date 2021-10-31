using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables   
    public float health;
    public GameObject player;
    public float ShootTiming;
    private float currentTime;
    public GameObject bullet;
    private Transform bulletSpawned;
    private Transform bulletSpawnPoint;
    private Transform pistolHolder;
    private Transform progressBar;
    public ScaryBar scaryBarScript;
    public GameObject scaryBar;
    public bool scared = false;
    public Transform[] alarms;
    //public float movementSpeed;
    private UnityEngine.AI.NavMeshAgent agent;

    
    

    //Methods 

    public void Start() 
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ScareEnemy(); //tots espantats al començar el atrac(canviar pel joc final a quan es realitza el primer dispar) 
        player = GameObject.FindWithTag("Player");
        if(this.tag == "Guard")
        {
            pistolHolder = this.transform.GetChild(0);
            bulletSpawnPoint = pistolHolder.GetChild(2);
        } 
        /*if(this.tag == "Worker")
        {
            GameObject alarmHolder = GameObject.FindWithTag("alarms"); //inicializar las alarmas
            alarms[0] = alarmHolder.transform.GetChild(0);
            alarms[1] = alarmHolder.transform.GetChild(1);
            alarms[2] = alarmHolder.transform.GetChild(2);
        }*/   
    }
    public void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        //this.transform.LookAt(player.transform); //enemy miri sempra al player

        if(this.tag == "Guard")
        {
            if(!scared) 
            {
                var qTo = Quaternion.LookRotation(player.transform.position - transform.position);
                qTo = Quaternion.Slerp(transform.rotation, qTo, 10 * Time.deltaTime);
                GetComponent<Rigidbody>().MoveRotation(qTo);

                if(currentTime >= ShootTiming)
                {
                    currentTime = 0;
                    Shoot();
                }
                currentTime += Time.deltaTime;
            }    
        } 
        //Enemy Movement
        if(this.tag == "Guard")
        {

        }
        else if(this.tag == "Worker" && !TimerManager.alarmaApretada && scared == false)
        {
            var nearestDist = float.MaxValue;
            Transform nearestObj = null;
            foreach(var alarm in alarms) 
            {
                if(Vector3.Distance(this.transform.position, alarm.transform.position) < nearestDist) 
                {
                    nearestDist = Vector3.Distance(this.transform.position, alarm.transform.position);
                    nearestObj = alarm; 
                }
            }
            agent.destination = nearestObj.transform.position;
            
        }
        else if(this.tag == "Worker" && (TimerManager.alarmaApretada || scared)) //per evitar que es moguin pelr culpa navmesh
        {
            agent.destination = transform.position;        
        }

    }

    public void Die()
    {
        Destroy(this.gameObject); //treure pel joc
    }
    public void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawnPoint.transform.position, transform.rotation);       
    }
    public void ScareEnemy() 
    {
        scared = true;
        scaryBar.SetActive(true);
        scaryBarScript.SetMaxTime();
    }
}
