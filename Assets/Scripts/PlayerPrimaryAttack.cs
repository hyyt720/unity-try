using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    //����������
    private int comboCounter;
    //�ϴ�����ʱ��
    private float lastTimeAttacked;
    //����������ֵ
    private float comboWindow = 2;
    
    public PlayerPrimaryAttack(Player _player, PlayerStateMachine _statemachine, string animBoolname) : base(_player, _statemachine, animBoolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //����������>2����ô�ع�Ϊ��һ�ι��������������������������������ͬ���ع�Ϊ��һ�ι���
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow) comboCounter = 0;

        player.anim.SetInteger("ComboCounter", comboCounter);
        //����0.1s�ṩ������Ե���Ȼ
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
        //����������������ֹ����
        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
