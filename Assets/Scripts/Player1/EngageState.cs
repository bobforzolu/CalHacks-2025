using System.AnimationSystem;

namespace Player1
{
    public class EngageState:PlayerState
    {
        public EngageState(CoupleStateMachine controller, AnimationController animationController) : base(controller, animationController)
        {
        }
    }
}