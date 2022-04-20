using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    public MoveState(Move player) : base (player)
    {

    }
    public override void update()
    {
        o_player.bodyTransform.Translate(new Vector3(0.1f * Time.deltaTime * o_player.walkSpeed * o_player.hor, 
            0
            , 0.1f * Time.deltaTime * o_player.walkSpeed * o_player.vert));
        //o_player.bodyTransform.Rotate(new Vector3(0, 0.0000000001f, 0), o_player.hor * o_player.rotateSpeed);



        if (o_player.vert <= 0.1f)
        {
            o_player.SetState(o_player._idlestate);
        }

        //throw new System.NotImplementedException();
    }

    public override void OnStateBegin()
    {
        Debug.Log("WalkState");
        o_player.bodyAnimator.SetBool("Walk", true);
    }
}
