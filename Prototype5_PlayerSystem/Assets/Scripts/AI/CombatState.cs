using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : AIState
{
    public AIAttackState attackState;
    public AIChasingState chasingState;
    public override AIState Tick(EnemyManager em, EnemyStats es, EnemyAnimationManager eam)
    {
        em.distanceFromTarget = Vector3.Distance(em.character.transform.position, em.transform.position);

        if (em.currentRecoveryTime <= 0 && em.distanceFromTarget <= em.maximumAttackRange)
        {
            return attackState;
        }
        else if (em.distanceFromTarget > em.maximumAttackRange)
        {
            return chasingState;
        }
        else
        {
            return this;
        }
    }
}
