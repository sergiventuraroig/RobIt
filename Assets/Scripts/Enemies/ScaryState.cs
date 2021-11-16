using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryState : IEnemyState
{
    EnemyAI myEnemy;
    

    
    // Cuando llamamos al constructor, guardamos 
    // una referencia a la IA de nuestro enemigo
    public ScaryState(EnemyAI enemy)
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
        //if(myEnemy.scaryBarScript)
    }
    
   
    // Como ya estamos en el estado Scary, no
    // llamaremos nunca a esta función desde 
    // este estado
    public void GoToScaryState() {}

    public void GoToStandardState() 
    {
        myEnemy.currentState = myEnemy.standardState;    
    }
    public void GoToBraveState() 
    { 
        //activamos su movimiento 
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
    }
    //A priori nunca dispararan mientras estén en este estado
    public void Shoot() {}


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
