using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    public AIChasingState chasingState;
    public LayerMask detectionLayer;
    public override AIState Tick(EnemyManager em, EnemyStats es, EnemyAnimationManager eam)
    {
        #region Handle Enemy Target Detection
        Collider[] colliders = Physics.OverlapSphere(transform.position, em.detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Move move = colliders[i].transform.GetComponent<Move>();
            if (move != null)
            {
                Vector3 targetDirection = move.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                if (viewableAngle > em.minimumDetectionAngle && viewableAngle < em.maximumDetectionAngle)
                {
                    em.character = move;
                   
                }
            }
        }
        #endregion

        #region Handle Switch to
        if (em.character != null)
        {
            return chasingState;
        }
        else
        {
            return this;
        }
        #endregion

    }
}
