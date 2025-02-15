using System.AnimationSystem;

namespace Player1
{
    public class JumpState: PlayerState
    {
        public JumpState(CoupleStateMachine controller, AnimationController animationController) : base(controller, animationController)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }
    }
}