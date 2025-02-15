using System.AnimationSystem;

namespace Player1
{
    public class AbilityState: PlayerState
    {
        public AbilityState(CoupleStateMachine controller, AnimationController animationController) : base(controller, animationController)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
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
}