using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector] public ScaryState scaryState;
    [HideInInspector] public StandardState standardState;
    [HideInInspector] public BraveState braveState;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    [HideInInspector] public GameObject player;
    public float health;
    public float ShootTiming;
    [HideInInspector] public float currentTime;
    public ScaryBar scaryBarScript;
    public GameObject scaryBar;
    public GameObject bullet;
    [HideInInspector] public Transform bulletSpawnPoint;
    private Transform pistolHolder;
    [HideInInspector] public bool  isGuard;
    [HideInInspector] public bool  isWorker;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent agent;
    public Transform[] alarms;
    public Transform rayOrigin;
    public GameObject enemyObject;
    [HideInInspector] public bool hasObject; //per identificar si té arma o mobil
    public GameObject armery;

    void Start()
    {
        // Creamos los estados de nuestra IA.
        scaryState = new ScaryState(this);
        standardState  = new StandardState(this);
        braveState  = new BraveState(this);
        // Le decimos que inicialmente empezará en Idle
        currentState = scaryState;
        currentState.ScareEnemy(); //per començar l'atrac amb l'estat scared
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        currentTime = 0;
        hasObject = true;
        
        if(this.tag == "Guard")
        {
            isGuard = true;
            isWorker = false;
            pistolHolder = this.transform.GetChild(0);
            bulletSpawnPoint = pistolHolder.GetChild(2);
        } 
        else if(this.tag == "Worker") 
        {
            isGuard = false;
            isWorker = true;
        }
        /*if(this.tag == "Worker")
        {
            GameObject alarmHolder = GameObject.FindWithTag("alarms"); //inicializar las alarmas
            alarms[0] = alarmHolder.transform.GetChild(0);
            alarms[1] = alarmHolder.transform.GetChild(1);
            alarms[2] = alarmHolder.transform.GetChild(2);
        }*/ 
        
    }
    
    void Update()
    {
        // Como nuestros estados no heredan de
        // MonoBehaviour, no se llama a su update 
        // automáticamente, y nos encargaremos 
        // nosotros de llamarlo a cada frame.
        currentState.UpdateState();

    }
    void LateUpdate() {
            
    }
    

    // Ya que nuestros states no heredan de 
    // MonoBehaviour, tendremos que avisarles
    // cuando algo entra, está o sale de nuestro
    // trigger.
    void OnTriggerEnter(Collider col)
    {
        currentState.OnTriggerEnter(col);
    }

    void OnTriggerStay(Collider col)
    {
        currentState.OnTriggerStay(col);
    }

    void OnTriggerExit(Collider col)
    {
        currentState.OnTriggerExit(col);
    }    
}