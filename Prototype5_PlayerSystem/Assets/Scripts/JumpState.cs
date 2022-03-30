using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    public JumpState(Move player) : base(player)
    {

    }
    public override void OnStateBegin()
    {
        Debug.Log("JumpState");
        o_player.rigidBody.AddForce(new Vector3(0, 2, 0) * o_player.rotateForce);
        o_player.bodyAnimator.SetBool("Jump", true);
    }

    public override void update()
    {
        if (o_player.states.shortNameHash == Move.JumpState)
        {
            if (!o_player.bodyAnimator.IsInTransition(0))
            {

                o_player.SetState(o_player._idlestate);
            }
        }
        
    }
}
