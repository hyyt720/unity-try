using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    //连击计数器
    private int comboCounter;
    //上次连击时间
    private float lastTimeAttacked;
    //连击间隔最大值
    private float comboWindow = 2;
    
    public PlayerPrimaryAttack(Player _player, PlayerStateMachine _statemachine, string animBoolname) : base(_player, _statemachine, animBoolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //若连击次数>2，那么回归为第一段攻击，若连击间隔大于最大连击间隔，则同样回归为第一段攻击
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow) comboCounter = 0;

        player.anim.SetInteger("ComboCounter", comboCounter);
        //保留0.1s提供间隔，显得自然
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
        //当触发器触发，终止攻击
        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
