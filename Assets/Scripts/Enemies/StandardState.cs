using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardState : IEnemyState
{
    EnemyAI myEnemy;
    
    // Cuando llamamos al constructor, guardamos 
    // una referencia a la IA de nuestro enemigo
    public StandardState(EnemyAI enemy)
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
        if(myEnemy.isGuard)
        {
            //rotar la cabeza mientras está agachado
            
        } 
        //Worker quieto???
        myEnemy.navMeshAgent.isStopped = true;
        
        myEnemy.transform.LookAt(myEnemy.player.transform);
        
        //Detectar si el jugador es visible
        if(Physics.Raycast(myEnemy.rayOrigin.transform.position, myEnemy.transform.forward, out RaycastHit hit, 30f ))
        {
            Debug.DrawRay(myEnemy.rayOrigin.transform.position, myEnemy.transform.forward  * 30f, Color.red);
            
            if(hit.collider.tag == "Player") {
                Debug.Log("Player cerca");        
            }
            else {
                Debug.Log("going brave");
                GoToBraveState();  
            }
        }
    }
    
    public void GoToScaryState()
    {
        //paramos su movimiento
        myEnemy.navMeshAgent.isStopped = true;
        myEnemy.currentState = myEnemy.scaryState;
    }

    // Como ya estamos en el estado Standard, no
    // llamaremos nunca a esta función desde 
    // este estado
    public void GoToStandardState() { }
    public void GoToBraveState() 
    { 
        myEnemy.currentState = myEnemy.braveState;
        myEnemy.navMeshAgent.isStopped = false;
    }
    public void Die() {
        GameObject.Destroy(myEnemy.gameObject);
    }
    public void ScareEnemy() 
    {
        myEnemy.scaryBar.SetActive(true);
        myEnemy.scaryBarScript.SetMaxTime();
        GoToScaryState();
    }
    //A priori nunca dispararan mientras estén en este estado
    public void Shoot() { }
    
    public void OnTriggerEnter(Collider col)
    {

    }
    public void OnTriggerStay(Collider col) 
    { 
        
    }
    public void OnTriggerExit(Collider col) 
    { 

    }
}
