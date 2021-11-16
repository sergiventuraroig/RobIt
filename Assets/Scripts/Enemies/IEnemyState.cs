using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void UpdateState();
    void GoToScaryState();
    void GoToStandardState();
    void GoToBraveState();
    void OnTriggerEnter(Collider col);
    void OnTriggerStay(Collider col);
    void OnTriggerExit(Collider col);  
    void Die();  
    void ScareEnemy(); 
    void Shoot();    
}
