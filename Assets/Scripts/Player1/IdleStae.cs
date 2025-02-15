using System.AnimationSystem;
using Player1;
using UnityEngine;

public class IdleStae : PlayerState
{
    public IdleStae(CoupleStateMachine controller, AnimationController animationController) : base(controller, animationController)
    {
    }

    public override void Enter()
    {
        base.Enter();
        animationController.PlayAnimation("Generic","idle");
    }

    public override void Update()
    {
        base.Update();
        if(controller.movement != Vector2.zero)
            controller.SwithState(controller.movementState);
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
