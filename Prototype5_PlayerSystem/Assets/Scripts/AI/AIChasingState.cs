using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChasingState : AIState
{
    public CombatState combatState;
    public override AIState Tick(EnemyManager em, EnemyStats es, EnemyAnimationManager eam)
    {
        if (em.isPerformingAction)
            return this;
        Vector3 targetDirection = em.character.transform.position - transform.position;
         em.distanceFromTarget = Vector3.Distance(em.character.transform.position, transform.position);
        float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);

        if (em.distanceFromTarget > em.maximumAttackRange)
        {
            eam.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
        }
        HandleRotateTowardsTarget(em);
        em.navmeshAgent.transform.localPosition = Vector3.zero;
        em.navmeshAgent.transform.localRotation = Quaternion.identity;
        if(em.distanceFromTarget <= em.maximumAttackRange)
        {
            return combatState;
        }
        else
        {
            return this;
        }
       
    }
    private void HandleRotateTowardsTarget(EnemyManager em)
    {
        if (em.isPerformingAction)
        {
            Vector3 direction = em.character.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();
            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            em.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, em.rotationSpeed / Time.deltaTime);
        }
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(em.navmeshAgent.desiredVelocity);
            Vector3 targetVelocity = em.enemyRigidBody.velocity;

            em.navmeshAgent.enabled = true;
            em.navmeshAgent.SetDestination(em.character.transform.position);
            em.enemyRigidBody.velocity = targetVelocity;
            em.transform.rotation = Quaternion.Slerp(transform.rotation, em.navmeshAgent.transform.rotation, em.rotationSpeed / Time.deltaTime);
        }

    }
}
