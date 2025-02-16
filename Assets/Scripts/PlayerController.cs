using System;
using System.AnimationSystem;
using System.Components;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour,IHealth
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
    public bool IsHit;


    public float switchSpeed;
    
    
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

    private void OnDisable()
    {
        inputController.Move -= InputControllerOnMove;
        inputController.Attack -= InputControllerOnAttack;
        inputController.Utility -= InputControllerOnUtility;
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
        if(IsHit)
            return;
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
            
            
          
          
            wife.transform.DOMoveX(player1.position.x, switchSpeed).SetEase(Ease.OutFlash);

            wife.transform.parent = player1;
            
            coupleStateMachine = wife.GetComponent<CoupleStateMachine>();

            husband.transform.DOMoveX(player2.position.x, switchSpeed).SetEase(Ease.OutFlash);

            husband.transform.parent = player2;

        }
        else
        {
            wife.transform.DOMoveX(player2.position.x, switchSpeed).SetEase(Ease.OutFlash);
            wife.transform.parent = player2;

            husband.transform.DOMoveX(player1.position.x, switchSpeed).SetEase(Ease.OutFlash);
            husband.transform.parent = player1;
            coupleStateMachine = husband.GetComponent<CoupleStateMachine>();


        }
        coupleStateMachine.ControlEnabled(true);

        
    }

    public void TakeDamege()
    {
        if(IsHit == true)
            return;
        
        movementComponent.rigidbody.DOMoveX(transform.position.x - 10.5f, 0.2f).SetEase(Ease.Flash).OnComplete(() =>
        {
            IsHit = false;
        }).OnStart(()=>IsHit = true);
    }

    public void HealHealth()
    {
        throw new NotImplementedException();
    }
}


public enum ActivePlayer
{
    husband,
    wife
}
