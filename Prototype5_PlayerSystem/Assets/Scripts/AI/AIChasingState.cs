using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChasingState : AIState
{
    public override AIState Tick(EnemyManager em, EnemyStats es, EnemyAnimationManager eam)
    {
        return this;
    }
}
