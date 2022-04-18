using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public  bool isPerformingAction;
    EnemyLocomotionManager elm;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50f;
    public float maximumDetectionAngle = 50f;


    void Start()
    {
        
    }
    private void Awake()
    {
        elm = GetComponent<EnemyLocomotionManager>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        handleCurrentAction();
    }
    void handleCurrentAction()
    {
        if (elm.character == null)
        {
            elm.HandleDetection();
        }
        else if (elm.distanceFromTarget > elm.stoppingDistance)
        {
            elm.HandleMoveToTarget();
        }
        else if (elm.distanceFromTarget <= elm.stoppingDistance)
        { 
            
        }

        #region Attacks

        void GetNewAttack()
        {
            Vector3 targetDirection = elm.character.transform.position - transform.position;
            float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);
            elm.distanceFromTarget = Vector3.Distance(elm.character.transform.position, transform.position);

            int maxScore = 0;
            for(int i = 0;  i < enemyAttacks.Length;i++)
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];
                if(elm.distanceFromTarget <= enemyAttackAction.maximumAttackAngle && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    if(viewAbleAngle <= enemyAttackAction.maximumAttackAngle
                        && viewAbleAngle>=enemyAttackAction.minimumAttackAngle)
                    {
                        maxScore += enemyAttackAction.attackScore;
                    }
                    
                }


            }
            int randomValue = Random.Range(0, maxScore);
            int temporaryScore = 0;

            for(int i = 0; i < enemyAttacks.Length;i++)
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];
                if (elm.distanceFromTarget <= enemyAttackAction.maximumAttackAngle && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    if (viewAbleAngle <= enemyAttackAction.maximumAttackAngle
                        && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
                    {
                        if (currentAttack != null)
                            return;
                        temporaryScore += enemyAttackAction.attackScore;

                        if(temporaryScore > randomValue)
                        {
                            currentAttack = enemyAttackAction;
                        }
                    }

                }
            }


        }
         
        #endregion
    }
}
