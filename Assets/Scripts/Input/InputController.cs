using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour,InputSystem_Actions.IPlayerActions
{
    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction<bool> Attack = delegate { };
    public event UnityAction<bool> IsAttackHeld = delegate { };

    public event UnityAction<bool> Utility = delegate { };

    public event UnityAction<bool,bool> DashAction = delegate { };

    private bool AttackIsheld;
    private bool dashIsHeld;
    private float dashTime;
    private float dashmaxHoldTime = 0.35f;

    private InputSystem_Actions PlayerActions;

   private void Awake()
   {
       PlayerActions = new InputSystem_Actions();
       PlayerActions.Player.SetCallbacks(this);
       PlayerActions.Player.Enable();    
   }

   public void OnMove(InputAction.CallbackContext context)
    {
        Move?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackIsheld = true;
            IsAttackHeld?.Invoke(AttackIsheld);
        }
        if (context.performed)
        {
            Attack?.Invoke(true);
        }
        
        if (context.canceled)
        {
            Attack?.Invoke(false);
        }
        if (context.canceled && AttackIsheld)
        {
            AttackIsheld = false;
            IsAttackHeld?.Invoke(AttackIsheld);
        }
        
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            dashTime = Time.time + dashmaxHoldTime;
            dashIsHeld = true;
        }

        if (context.canceled && dashIsHeld)
        {
            dashIsHeld = false;
            DashAction?.Invoke(true,dashIsHeld);


        }
    }

    public void OnUtility(InputAction.CallbackContext context)
    {
      
        if (context.performed)
        {
            Utility?.Invoke(true);
        }
         if(context.canceled)
        {
            Utility?.Invoke(false);
        }
    }


    private void Update()
    {
        if (dashIsHeld & Time.time >= dashTime)
        {
           
            DashAction?.Invoke(true,dashIsHeld);
            dashIsHeld = false;
            
        }
    }
}
