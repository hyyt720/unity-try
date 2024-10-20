using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonBattleState : EnemyState
{
    private Transform player;
    private Enemy_Skelton enemy;
    private int moveDir;
    public SkeltonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,Enemy_Skelton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
        Debug.Log("I See You!");
        stateTimer = enemy.battleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDetected().distance != 0 && enemy.IsPlayerDetected().distance<enemy.attackDistance) 
        {
         // Debug.Log(enemy.IsPlayerDetected().distance); 
            if (CanAttack()) stateMachine.ChangeState(enemy.attackState);
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 15) stateMachine.ChangeState(enemy.idleState);
        }
        if (player.position.x > enemy.transform.position.x) moveDir = 1;
        else if (player.position.x < enemy.transform.position.x) moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDir, enemy.rb.velocity.y);
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.LastTimeAttack + enemy.attackCoolDown)
        {
            return true;
        }
        return false;
    }
}
