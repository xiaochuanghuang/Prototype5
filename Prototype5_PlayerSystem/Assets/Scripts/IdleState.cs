using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public IdleState(Move player) : base(player)
    {

    }
    public override void update()
    {
        //Debug.Log(o_player.vert);
        if (o_player.vert > 0.1f)
        {
            o_player.SetState(o_player._movestate);
        }
    }

    public override void OnStateBegin()
    {
        Debug.Log("IdleState");
        o_player.bodyAnimator.SetBool("Walk", false);
        //o_player.bodyAnimator.SetBool("Jump", false);
        o_player.bodyAnimator.SetBool("Attack01", false);
      
    }
}
