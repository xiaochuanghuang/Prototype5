using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2State : IState
{
    public Attack2State(Move player) : base(player)
    {

    }
    public override void OnStateBegin()
    {
        Debug.Log("Attack2State");
        o_player.transform.Find("HitArea").gameObject.SetActive(true);
        o_player.bodyAnimator.SetBool("Attack02", true);
    }

    public override void update()
    {
        if (o_player.states.shortNameHash == Move.attack2State)
        {
            if (!o_player.bodyAnimator.IsInTransition(0))
            {

                o_player.SetState(o_player._idlestate);
               o_player.transform.Find("HitArea").gameObject.SetActive(false);
            }
        }
    }


}
