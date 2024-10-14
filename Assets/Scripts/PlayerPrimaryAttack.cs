using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow = 2;
    
    public PlayerPrimaryAttack(Player _player, PlayerStateMachine _statemachine, string animBoolname) : base(_player, _statemachine, animBoolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow) comboCounter = 0;

        player.anim.SetInteger("ComboCounter", comboCounter);
        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0) rb.velocity = new Vector2(0, 0);

        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
