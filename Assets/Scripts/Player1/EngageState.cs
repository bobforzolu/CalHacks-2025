﻿using System.AnimationSystem;

namespace Player1
{
    public class EngageState:PlayerState
    {
        public EngageState(CoupleStateMachine controller, AnimationController animationController) : base(controller, animationController)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animationController.PlayAnimation("Attack","a1");

        }

        public override void Update()
        {
            base.Update();
        }

        public override void HeroEventStates(AniamtionEventType eventType)
        {
            base.HeroEventStates(eventType);
            if(eventType == AniamtionEventType.AnimationFinishTrigger)
                controller.SwithState(controller.idleStae);
        }
    }
}