using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    public DeathState(Move player) : base(player)
    {

    }

    public override void OnStateBegin()
    {

        o_player.bodyAnimator.SetBool("Death", true);

    }

    public override void update()
    {

    }
}
