using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public AttackState(Move player) : base(player)
    {

    }
    public override void OnStateBegin()
    {
        Debug.Log("AttackState");
        o_player.bodyAnimator.SetBool("Attack", true);
        o_player.transform.Find("HitArea").gameObject.SetActive(true);
    }

    public override void update()
    {
        if (o_player.states.shortNameHash == Move.attackState)
        {
            if (!o_player.bodyAnimator.IsInTransition(0))
            {

                o_player.SetState(o_player._idlestate);
                o_player.transform.Find("HitArea").gameObject.SetActive(false);
            }
        }

    }
}
