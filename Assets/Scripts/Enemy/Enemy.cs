using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    public LayerMask whatIsPlayer;

    [Header("Move info")]
    public float moveSpeed;
    public float IdleTime;
    public float battleTime;

    [Header("Attack info")]
    public float attackDistance;
    public float attackCoolDown;
    public float LastTimeAttack;

    public EnemyStateMachine stateMachine {  get; private set; }
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();


    }
    
    public virtual void AnimationFinishTrigger() =>stateMachine.currentState.AnimationFinishTrigger();
    public virtual void AnimationMiddleTrigger() => stateMachine.currentState.AnimationMiddleTrigger();

    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);
}
