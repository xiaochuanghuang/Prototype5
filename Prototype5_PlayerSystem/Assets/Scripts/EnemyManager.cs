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
    EnemyStats es;
    public NavMeshAgent navmeshAgent;

    public AIState currentState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;

   public float distanceFromTarget;
    //public float stoppingDistance = 0.5f;
    public float rotationSpeed = 15.0f;
    public float maximumAttackRange = 1.5f;

    public Rigidbody enemyRigidBody;

    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50f;
    public float maximumDetectionAngle = 50f;
    public float viewableAngle;

    public float currentRecoveryTime = 0f;

    void Start()
    {
        enemyRigidBody.isKinematic = false;
    }
    private void Awake()
    {
        elm = GetComponent<EnemyLocomotionManager>();
        eam = GetComponentInChildren<EnemyAnimationManager>();
        es = GetComponent<EnemyStats>();
        navmeshAgent = GetComponentInChildren<NavMeshAgent>();
        navmeshAgent.enabled = false;
        enemyRigidBody = GetComponent<Rigidbody>();
   
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
        //if(elm.character!=null)
        //{
        //    elm.distanceFromTarget = Vector3.Distance(elm.character.transform.position, transform.position);
        //}
      
        //if (elm.character == null)
        //{
        //    elm.HandleDetection();
        //}
        //else if (elm.distanceFromTarget > elm.stoppingDistance)
        //{
        //    elm.HandleMoveToTarget();
        //}
        //else if (elm.distanceFromTarget <= elm.stoppingDistance)
        //{
        //    AttackTarget();
        //}
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
