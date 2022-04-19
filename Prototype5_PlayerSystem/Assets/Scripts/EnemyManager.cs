using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Move character;
    public  bool isPerformingAction;
    EnemyLocomotionManager elm;
    EnemyAnimationManager eam;
    public EnemyStats es;
    public NavMeshAgent navmeshAgent;
    public Rigidbody enemyRigidBody;
    public float distanceFromTarget;
    //public float stoppingDistance = 0.5f;
    public float rotationSpeed = 15.0f;
    public float maximumAttackRange = 1.5f;

    public AIState currentState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    public float viewableAngle;
    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50f;
    public float maximumDetectionAngle = 50f;

    public float currentRecoveryTime = 0f;
    public GameObject hitArea;

    void Start()
    {
        enemyRigidBody.isKinematic = false;
    }
    private void Awake()
    {
        elm = GetComponent<EnemyLocomotionManager>();
        eam = GetComponentInChildren<EnemyAnimationManager>();
        es = GetComponent<EnemyStats>();
        enemyRigidBody = GetComponent<Rigidbody>();
        navmeshAgent = GetComponentInChildren<NavMeshAgent>();
        navmeshAgent.enabled = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        handleRecoveryTimer();
    }

    private void FixedUpdate()
    {
        handleStateMachine();
    }
    void handleStateMachine()
    {
        if(currentState != null)
        {
            AIState nextState = currentState.Tick(this,es,eam);

            if(nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }
    }
    private void SwitchToNextState(AIState state)
    {
        currentState = state;
    }    

    void handleRecoveryTimer()
    {
        if(currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }
        if(isPerformingAction)
        {
            if(currentRecoveryTime <= 0)
            {
                isPerformingAction = false;
            }
        }
    }
}
