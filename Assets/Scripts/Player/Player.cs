using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: Entity
{
    //各变量
    [Header("Attack details")]
    public Vector2[] attackMovement;

    [Header("Move info")]
    [SerializeField] public float moveSpeed = 15f;
    [SerializeField] public float jumpSpeed = 15f;

    [Header("Dash info")]
    [SerializeField] public float dashSpeed = 25f;
    [SerializeField] public float dashDuration = 1.5f;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashUsageTimer;
    [SerializeField] public float dashDir { get; private set; }

    


    

    //状态声明
    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set;}
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; } 
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }

    public PlayerPrimaryAttack primaryAttack { get; private set; }

    public PlayerDashAttack dashAttack { get; private set; }
    #endregion

    protected override void Awake()
    {
        //变量初始化
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");

        primaryAttack = new PlayerPrimaryAttack(this, stateMachine, "Attack");
        dashAttack = new PlayerDashAttack(this, stateMachine, "DashAttack");
    }

    protected override void Start()
    {
        //组件绑定
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base .Update();
        stateMachine.currentState.Update();
        CheckForDashInput();
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    //检测冲刺
    private void CheckForDashInput()
    {
        if (IsWallDetected()) return;
        
        dashUsageTimer -= Time.deltaTime;

        
        if (Input.GetKeyDown(KeyCode.LeftShift)&&dashUsageTimer<0) 
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0) dashDir = facingDir;
            stateMachine.ChangeState(dashState);
        }
    }

    

    


    
}
