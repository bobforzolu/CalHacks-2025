using System;
using System.AnimationSystem;
using System.Components;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ActivePlayer activePlayer;
    public InputController inputController;
    
    public Transform player1;
    public Transform player2;

    public GameObject husband;
    public GameObject wife;
    public CoupleStateMachine coupleStateMachine;
    public event Action<ActivePlayer> OnActivePlayerChanged; 
    
    public MovementComponent movementComponent;
    
    private Vector2 movement;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        OnActivePlayerChanged += SwitchActivePlayer;
        movementComponent = GetComponent<MovementComponent>();
        inputController.Move += InputControllerOnMove;
        inputController.Attack += InputControllerOnAttack;
        inputController.Utility += InputControllerOnUtility;

        foreach (CoupleStateMachine stateMachine in GetComponentsInChildren<CoupleStateMachine>())
        {
            stateMachine.Initalize();
        }

    }

    private void InputControllerOnUtility(bool arg0)
    {
        if(coupleStateMachine == null)
            return;
        if(arg0)
          SwitchInput();
    }

    private void InputControllerOnAttack(bool arg0)
    {
        if(coupleStateMachine == null)
            return;
        
        if(arg0)
          coupleStateMachine.Attack();
    }

    private void InputControllerOnMove(Vector2 axis)
    {
        movement = axis;
    }

    void Start()
    {
      
        OnActivePlayerChanged?.Invoke(activePlayer);
        
    }

    // Update is called once per frame
    void Update()
    {
        movementComponent.SetVelocity(4, movement);
        movementComponent.LogicUpdate();
       
        
    }

    public void SwitchInput()
    {
       
            if (activePlayer == ActivePlayer.wife)
            {
                activePlayer = ActivePlayer.husband;
                OnActivePlayerChanged?.Invoke(activePlayer);
                
            }else if (activePlayer == ActivePlayer.husband)
            {
                activePlayer = ActivePlayer.wife;
                OnActivePlayerChanged?.Invoke(activePlayer);
            }
        
    }


    public void SwitchActivePlayer( ActivePlayer newPlayer )
    {

        if (coupleStateMachine != null)
        {
            coupleStateMachine.ControlEnabled(false);
        }

        if (activePlayer == ActivePlayer.wife)
        {
            
            
            wife.transform.position = player1.position;
            wife.transform.parent = player1;
            coupleStateMachine = wife.GetComponent<CoupleStateMachine>();

            husband.transform.position = player2.position;
            husband.transform.parent = player2;
            transform.position = wife.transform.position;

        }
        else
        {
            wife.transform.position = player2.position;
            wife.transform.parent = player2;

            husband.transform.position = player1.position;
            husband.transform.parent = player1;
            coupleStateMachine = husband.GetComponent<CoupleStateMachine>();

            transform.position = husband.transform.position;

        }
        coupleStateMachine.ControlEnabled(true);

        
    }
}


public enum ActivePlayer
{
    husband,
    wife
}
