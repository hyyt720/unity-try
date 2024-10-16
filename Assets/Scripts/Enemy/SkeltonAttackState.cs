using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonAttackState : EnemyState
{
    private Enemy_Skelton enemy;
    
    public SkeltonAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,Enemy_Skelton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy= _enemy;
    }

    public override void Enter()
    {
        base.Enter();
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
        if(triggerCalled) { stateMachine.ChangeState(enemy.battleState); }
    }
}
