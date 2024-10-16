using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonMoveState : EnemyState
{
    private Enemy_Skelton enemy;
    protected Transform player;

    public SkeltonMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,Enemy_Skelton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, enemy.rb.velocity.y);
        if (enemy.IsWallDetected() || !enemy.IsGroundDetected()) 
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
        if (enemy.IsPlayerDetected()||Vector2.Distance(enemy.transform.position,player.position)<2) stateMachine.ChangeState(enemy.battleState);
    }
}
