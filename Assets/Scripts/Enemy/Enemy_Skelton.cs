using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skelton : Enemy
{
    #region States
    public SkeltonIdleState idleState {  get; private set; }
    public SkeltonMoveState moveState {  get; private set; }
    public SkeltonBattleState battleState { get; private set; }

    public SkeltonAttackState attackState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        idleState = new SkeltonIdleState(this, stateMachine, "Idle", this);
        moveState = new SkeltonMoveState(this, stateMachine, "Move", this);
        battleState = new SkeltonBattleState(this, stateMachine, "Move", this);
        attackState = new SkeltonAttackState(this, stateMachine, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
