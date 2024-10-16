using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _statemachine, string animBoolname) : base(_player, _statemachine, animBoolname)
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }

        if(xInput != 0)
        {
            if(player.facingDir != xInput)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
        if (yInput > 0) rb.velocity = new Vector2(0, rb.velocity.y * .7f);
        else rb.velocity = new Vector2(0, rb.velocity.y);
        if (player.IsGroundDetected()) stateMachine.ChangeState(player.idleState);
    }
}
