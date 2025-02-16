using System.AnimationSystem;

namespace Player1
{
    public class DisEngage:PlayerState
    {
        public DisEngage(CoupleStateMachine controller, AnimationController animationController) : base(controller, animationController)
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

        public override void HeroEventStates(AnimationEventType eventType)
        {
            base.HeroEventStates(eventType);
            if(eventType == AnimationEventType.AnimationFinishTrigger)
                controller.SwithState(controller.idleStae);
        }
    }
}