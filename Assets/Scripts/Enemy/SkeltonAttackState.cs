using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class SkeltonAttackState : EnemyState
{
    private Rigidbody2D playerRigidbody2D;
    private Enemy_Skelton enemy;
    
    public SkeltonAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,Enemy_Skelton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy= _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        playerRigidbody2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.LastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(0, 0);
        if(triggerCalled)
        {
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                RaycastHit2D hit = enemy.IsPlayerDetected();
                // 玩家被击中，应用击退力
                playerRigidbody2D.AddForce(new Vector2(-hit.normal.x * 300, -hit.normal.y * 10), ForceMode2D.Impulse);
                Debug.Log(hit.normal);
                // 可以在这里添加其他击中效果，比如播放击中动画、减少玩家生命值等
            }
        stateMachine.ChangeState(enemy.battleState);
        }
        if (triggerCalled1)
        {
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                RaycastHit2D hit = enemy.IsPlayerDetected();
                // 玩家被击中，应用击退力
                playerRigidbody2D.AddForce(new Vector2(-hit.normal.x * 15, -hit.normal.y * 10), ForceMode2D.Impulse);
                Debug.Log(hit.normal);
                // 可以在这里添加其他击中效果，比如播放击中动画、减少玩家生命值等
            }
        }
    }
}


