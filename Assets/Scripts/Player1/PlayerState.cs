using System.AnimationSystem;

namespace Player1
{
    public class PlayerState
    {
        protected CoupleStateMachine controller;
        protected AnimationController animationController;
        
        public  PlayerState(CoupleStateMachine controller, AnimationController animationController)
        {
            this.controller = controller;
            this.animationController = animationController;
        }
        public virtual void Enter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void HeroEventStates(AniamtionEventType eventType)
        {
        
        }
        
    }
}