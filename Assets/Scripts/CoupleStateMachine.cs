using System;
using System.AnimationSystem;
using System.Components;
using Player1;
using Unity.VisualScripting;
using UnityEngine;

public class CoupleStateMachine : MonoBehaviour
{
        public AnimationController animationController;
        public PlayerController playerController;
        public MovementComponent movementComponent;
        public CustomAnimationEvent animationEvent;
        public ActivePlayer PlayerId;
        public bool InControl = false;

        public int attackMovement;



        public void Initalize()
        {
            animationController.Initialize();
            IniatalizeStateMachine();
            movementComponent = GetComponent<MovementComponent>();
            
        
        }

        private void OnEnable()
        {
            animationEvent.OnAniamtion += AnimationEventOnOnAniamtion;

            GetComponentInParent<PlayerController>().OnActivePlayerChanged += OnOnActivePlayerChanged;
            GetComponentInParent<PlayerController>().inputController.Move += InputControllerOnMove;
        }

        private void OnDisable()
        {
           
        }

        private void OnDestroy()
        {
            animationEvent.OnAniamtion -= AnimationEventOnOnAniamtion;

            GetComponentInParent<PlayerController>().OnActivePlayerChanged -= OnOnActivePlayerChanged;
            GetComponentInParent<PlayerController>().inputController.Move -= InputControllerOnMove;
        }

        public void Attack()
        {
         
            
           SwithState(attackstate);
                
        }

        public void ControlEnabled( bool control)
        {
            InControl = control;
        }

    
        private void AnimationEventOnOnAniamtion(AniamtionEventType obj)
        {
           CurrentPlayerState.HeroEventStates(obj);
        }

        private void InputControllerOnMove(Vector2 arg0)
        {
          movement = arg0;
          movementComponent.CheckIfShouldFlip(arg0.x);
        }

        public void SwithControl(ActivePlayer activePlayer)
        {
            if (PlayerId == activePlayer)
            {
                SwithState(engage);
            }
            else
            {
                SwithState(disengage);
            }
                
        }

        private void OnOnActivePlayerChanged(ActivePlayer activePlayer)
        {
            SwithControl(activePlayer);
            if (activePlayer == PlayerId)
            {
                InControl = true;
            }
            else
            {
                InControl = false;
            }
        }

        private void Update()
        {
            CurrentPlayerState.Update();
        }


        #region StateMachine
    public PlayerState CurrentPlayerState;
    public AttackState attackstate;
    public SwitchAttack switchattack;
    public DisEngage disengage;
    public EngageState engage;
    public IdleStae idleStae;
    public JumpState jumpState;
    public MovementState movementState;
    public Vector2 movement;
    public void IniatalizeStateMachine()
    {
        attackstate = new AttackState(this, animationController);
        switchattack = new SwitchAttack(this, animationController);
        idleStae = new IdleStae(this, animationController);
        jumpState = new JumpState(this, animationController);
        movementState = new MovementState(this, animationController);
        engage = new EngageState(this, animationController);
        disengage = new DisEngage(this, animationController);
        
        
        initalizeState(idleStae);
        
        
    }

    public void initalizeState(PlayerState initalState)
    {
        CurrentPlayerState = initalState;
        CurrentPlayerState.Enter();
    }

    public void SwithState(PlayerState swithState)
    {
        CurrentPlayerState.Exit();
        CurrentPlayerState = swithState;
        CurrentPlayerState.Enter();
    }


    #endregion
}
