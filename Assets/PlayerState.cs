using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolname;

    protected float stateTimer;
    public PlayerState(Player _player,PlayerStateMachine _statemachine, string animBoolname)
    {
        this.player = _player;
        this.stateMachine = _statemachine;
        this.animBoolname = animBoolname;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolname, true);
        rb = player.rb;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolname, false);
    }
}
