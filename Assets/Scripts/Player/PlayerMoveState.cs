using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    // Start is called before the first frame update
    public PlayerMoveState(Player _player, PlayerStateMachine _statemachine, string animBoolname) : base(_player, _statemachine, animBoolname)
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
        if (!player.IsGroundDetected() && !player.IsEnemyDetected()) stateMachine.ChangeState(player.airState);
        
        player.SetVelocity(xInput * player.moveSpeed,rb.velocity.y);
        if (xInput == 0 || player.IsWallDetected()) stateMachine.ChangeState(player.idleState);
    }
}
