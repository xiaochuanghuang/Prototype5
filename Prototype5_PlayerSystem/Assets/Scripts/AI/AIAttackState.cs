using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIState
{
    public CombatState combatState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    public override AIState Tick(EnemyManager em, EnemyStats es, EnemyAnimationManager eam)
    {
        Vector3 targetDirection = em.character.transform.position - transform.position;
        float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);
        if (em.isPerformingAction)
            return combatState;



        GetNewAttack(em);
        if (currentAttack != null)
        {
            if (em.distanceFromTarget < currentAttack.minimumDistanceNeededToAttack)
            {
                return this;
            }
            else if (em.distanceFromTarget < currentAttack.maximumDistanceNeededToAttack)
            {
                if (em.viewableAngle <= currentAttack.maximumAttackAngle && em.viewableAngle >= currentAttack.minimumAttackAngle)
                {
                    if (em.currentRecoveryTime <= 0 && em.isPerformingAction == false)
                    {
                        eam.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                        eam.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
                        eam.playAnimation(currentAttack.actionAnimation, true);
                        em.isPerformingAction = true;
                        em.currentRecoveryTime = currentAttack.recoveryTime;
                        currentAttack = null;
                        return combatState;
                    }
                }
            }
        }
        else
        {
            GetNewAttack(em);
        }

        return combatState;
    }
    void GetNewAttack(EnemyManager em)
    {
        Vector3 targetDirection = em.character.transform.position - transform.position;
        float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);
        em.distanceFromTarget = Vector3.Distance(em.character.transform.position, transform.position);

        int maxScore = 0;
        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (em.distanceFromTarget <= enemyAttackAction.maximumAttackAngle && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
            {
                if (viewAbleAngle <= enemyAttackAction.maximumAttackAngle
                    && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    maxScore += enemyAttackAction.attackScore;
                }

            }


        }
        int randomValue = Random.Range(0, maxScore);
        int temporaryScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (em.distanceFromTarget <= enemyAttackAction.maximumAttackAngle && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
            {
                if (viewAbleAngle <= enemyAttackAction.maximumAttackAngle
                    && viewAbleAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    if (currentAttack != null)
                        return;
                    temporaryScore += enemyAttackAction.attackScore;

                    if (temporaryScore > randomValue)
                    {
                        currentAttack = enemyAttackAction;
                    }
                }

            }
        }


    }
}
