using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : PlayerState
{
    public PlayerDashAttack(Player _player, PlayerStateMachine _statemachine, string animBoolname) : base(_player, _statemachine, animBoolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0) rb.velocity = new Vector2(0, 0);
        //µ±´¥·¢Æ÷´¥·¢£¬ÖÕÖ¹¹¥»÷
        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
