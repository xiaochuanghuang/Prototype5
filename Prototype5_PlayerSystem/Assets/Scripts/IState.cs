using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class IState
{
    protected Move o_player;

    public IState(Move player)
    {
        o_player = player;
    }

    public abstract void OnStateBegin();

    public abstract void update();
}
