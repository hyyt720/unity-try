using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonIdleState : EnemyState
{

    Enemy_Skelton enemy;
    protected Transform player;

    public SkeltonIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skelton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.IdleTime;
        player = GameObject.Find("Player").transform;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2) stateMachine.ChangeState(enemy.battleState);
    }
}
