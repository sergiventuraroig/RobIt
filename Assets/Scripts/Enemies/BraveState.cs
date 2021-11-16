using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraveState : IEnemyState
{
    EnemyAI myEnemy;
    
    // Cuando llamamos al constructor, guardamos 
    // una referencia a la IA de nuestro enemigo
    public BraveState(EnemyAI enemy)
    {
        myEnemy = enemy;
    }

    // Aquí va toda la funcionalidad que queramos 
    // que haga el enemigo cuando esté en este estado.
    public void UpdateState()
    {

        if(myEnemy.health <= 0)
        {
            Die();
        }
        if(myEnemy.isGuard )
        {
            if(myEnemy.hasObject) {
                //rotar hacia el player 
                myEnemy.transform.LookAt(myEnemy.player.transform);
                //Saber si guardia ve al jugador
                if(Physics.Raycast(myEnemy.rayOrigin.transform.position, myEnemy.transform.forward, out RaycastHit hit, 30f ))
                { 
                    Debug.DrawRay(myEnemy.rayOrigin.transform.position, myEnemy.transform.forward  * 30f, Color.green);

                    if(hit.collider.tag == "Player") {

                        //Disparar si ha pasado el tiempo entre balas
                        if(myEnemy.currentTime >= myEnemy.ShootTiming)
                        {
                            myEnemy.currentTime = 0;
                            Shoot();
                        }
                        //evitar que se mueva si ya puede disparar
                        myEnemy.navMeshAgent.isStopped = true;
                    }
                    // Si no lo ve, va a por él
                    else {
                        myEnemy.agent.destination = myEnemy.player.transform.position; 
                        myEnemy.navMeshAgent.isStopped = false;   
                    }
                    
                }
                myEnemy.currentTime += Time.deltaTime;
            } 
            else
            {
                myEnemy.agent.destination = myEnemy.armery.transform.position; 
                myEnemy.navMeshAgent.isStopped = false;
            }
            
        } 
        //Worker va a pulsar alarma más cercana
        if(myEnemy.isWorker && !TimerManager.alarmaApretada) 
        {
            var nearestDist = float.MaxValue;
            Transform nearestObj = null;
            //Detectar la alarma que se encuentre más cerca
            foreach(var alarm in myEnemy.alarms) 
            {
                if(Vector3.Distance(myEnemy.transform.position, alarm.transform.position) < nearestDist) 
                {
                    nearestDist = Vector3.Distance(myEnemy.transform.position, alarm.transform.position);
                    nearestObj = alarm; 
                }
            }
            myEnemy.agent.destination = nearestObj.transform.position;
            
        }
        if (TimerManager.alarmaApretada) {
            myEnemy.navMeshAgent.isStopped = true;
        }
    }
    
    public void GoToScaryState()
    {
        //paramos su movimiento
        myEnemy.navMeshAgent.isStopped = true;
        myEnemy.currentState = myEnemy.scaryState;
    }

    
    public void GoToStandardState() 
    { 
        myEnemy.currentState = myEnemy.standardState;    
    }

    // Como ya estamos en el estado Brave, no
    // llamaremos nunca a esta función desde 
    // este estado
    public void GoToBraveState() { }
    public void Die() {
        GameObject.Destroy(myEnemy.gameObject);
    }
    public void ScareEnemy() 
    {
        myEnemy.scaryBar.SetActive(true);
        myEnemy.scaryBarScript.SetMaxTime();
        GoToScaryState();
    }
    public void Shoot()
    {
        GameObject.Instantiate(myEnemy.bullet.transform, myEnemy.bulletSpawnPoint.transform.position, myEnemy.transform.rotation);       
    }
    
    public void OnTriggerEnter(Collider col)
    {
        //player es troba a la armeria
        if(col.tag == "Armeria") 
        {
            if(myEnemy.isGuard)
            {
                myEnemy.hasObject = true;
                myEnemy.enemyObject.SetActive(true);   
            }        
        }   
    }
    public void OnTriggerStay(Collider col) 
    { 
        
    }
    public void OnTriggerExit(Collider col) 
    { 

    }
}