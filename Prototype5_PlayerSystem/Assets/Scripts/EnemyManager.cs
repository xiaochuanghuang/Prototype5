using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Move character;
    public  bool isPerformingAction;
    EnemyLocomotionManager elm;
    EnemyAnimationManager eam;
    EnemyStats es;
    public AIState currentState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50f;
    public float maximumDetectionAngle = 50f;

    public float currentRecoveryTime = 0f;

    void Start()
    {
        
    }
    private void Awake()
    {
        elm = GetComponent<EnemyLocomotionManager>();
        eam = GetComponentInChildren<EnemyAnimationManager>();
        es = GetComponent<EnemyStats>();
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
    #region Attacks

    void AttackTarget()
        {
            //if (isPerformingAction)
            //    return;


            //if(currentAttack == null)
            //{
            //    GetNewAttack();
            //}
            //else
            //{
            //    isPerformingAction = true;
            //    currentRecoveryTime = currentAttack.recoveryTime;
            //    eam.playAnimation(currentAttack.actionAnimation, true);
            //    currentAttack = null;
            //}
        }

        void GetNewAttack()
        {
            //Vector3 targetDirection = elm.character.transform.position - transform.position;
            //float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);
            //elm.distanceFromTarget = Vector3.Distance(elm.character.transform.position, transform.position);

            //int maxScore = 0;
            //for(int i = 0;  i < enemyAttacks.Length;i++)
            //{
            //    EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            //    if(elm.distanceFromTarget <= enemyAttackAction.maximumAttackAngle && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
            //    {
            //        if(viewAbleAngle <= enemyAttackAction.maximumAttackAngle
            //            && viewAbleAngle>=enemyAttackAction.minimumAttackAngle)
            //        {
            //            maxScore += enemyAttackAction.attackScore;
            //        }
                    
            //    }


            //}
            //int randomValue = Random.Range(0, maxScore);
            //int temporaryScore = 0;

            //for(int i = 0; i < enemyAttacks.Length;i++)
            //{
            //    EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            //    if (elm.distanceFromTarget <= enemyAttackAction.maximumAttackAngle && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
            //    {
            //        if (viewAbleAngle <= enemyAttackAction.maximumAttackAngle
            //            && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
            //        {
            //            if (currentAttack != null)
            //                return;
            //            temporaryScore += enemyAttackAction.attackScore;

            //            if(temporaryScore > randomValue)
            //            {
            //                currentAttack = enemyAttackAction;
            //            }
            //        }

            //    }
            //}


        }
         
        #endregion
   

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
