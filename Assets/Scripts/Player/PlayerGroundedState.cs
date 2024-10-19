using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _statemachine, string animBoolname) : base(_player, _statemachine, animBoolname)
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

        if (Input.GetKeyDown(KeyCode.Mouse0)) stateMachine.ChangeState(player.primaryAttack);

        if (!player.IsGroundDetected() && !player.IsEnemyDetected()) stateMachine.ChangeState(player.airState);
        
        if(Input.GetKeyDown(KeyCode.Space) && (player.IsGroundDetected() || player.IsEnemyDetected())) { stateMachine.ChangeState(player.jumpState); }
    }
}
