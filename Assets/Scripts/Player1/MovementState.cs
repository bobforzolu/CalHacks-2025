using System.AnimationSystem;
using Player1;
using UnityEngine;

public class MovementState : PlayerState
{
    public MovementState(CoupleStateMachine controller, AnimationController animationController) : base(controller, animationController)
    {
    }

    public override void Enter()
    {
        base.Enter();
        animationController.PlayAnimation("Generic","run");

    }

    public override void Update()
    {
        base.Update();
        if(controller.movement == Vector2.zero)
            controller.SwithState(controller.idleStae);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
