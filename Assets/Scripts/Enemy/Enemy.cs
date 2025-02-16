using System;
using System.Components;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour,IHealth
{
  public float AttackRange;
  public int Health;
  public float AttackCoolDown;
  public float MovementSpeed;
  public EnemyState enemyState;
  public LayerMask layerMask;
  public TextMeshPro textUi;
  public event Action<Enemy> OnDeath;
  [Header("Attack")]
  public float TimeBetweenAttacks;
  public float attacktime;
  public bool isAttacking;
  
  [Header("Idle settings")]
  public float idleDuration;
  public float idleTime;
  [Header("movment")]
  public bool isMoving;
  [Header("ai settings")] 
  public StructreController tartget;
  
  public Tweener moveTweener;

  [Header("Attack")] 
  public Sequence attacksequatnce;

  public bool testing;

  private void Awake()
  {
    if (testing)
    {
      textUi.text = "dasf";
      SetMovement();  


    }
      
  }

  public void Iniatalize(string text, StructreController tartget)
{
  textUi.text = text;
  this.tartget = tartget; 

}

  public void Deflect(int force)
  {
    idleTime = idleDuration + Time.time;
    enemyState = EnemyState.ishit;
    attacksequatnce?.Pause();
    moveTweener?.Kill();
    moveTweener = transform.DOMove(transform.position + (Vector3.right * force), 0.5f).SetEase(Ease.OutFlash);
  }


  
  public virtual void Attack(Vector2 direction)
  {
    
  }
  public virtual void Death()
  {
    
  }

  public void SetMovement()
  {
    enemyState = EnemyState.move;
    moveTweener = transform.DOMoveX(tartget.transform.position.x, MovementSpeed).SetSpeedBased().SetEase(Ease.Linear);

  }

  public void ChangeTOAttack(Vector2 direction)
  {
    moveTweener?.Pause();
    attacktime = TimeBetweenAttacks + Time.time;
    enemyState = EnemyState.attack;
    Attack(direction);
  }

  public void AttackFinish()
  {
  
  }





 
  private void Update()
  {
    transform.position = new Vector3(transform.position.x, -0.25f, transform.position.z);

    switch (enemyState)
    {
      case EnemyState.Idle:
        if( Time.time >idleTime )
          SetMovement();
        break;
      case EnemyState.move:
        CheckLeftRightRaycast();
        if(Vector3.Distance(transform.position, tartget.transform.position) <5f)
          moveTweener?.Kill();
          

        break;
      case EnemyState.attack:
        break;
      case EnemyState.ishit:
        if( Time.time >idleTime )
          SetMovement();
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
  
  
  void CheckLeftRightRaycast()
  {
    // Define left and right directions
    Vector3 leftDirection = -transform.right;
    Vector3 rightDirection = transform.right;

    // Perform Raycasts
    bool hitLeft = PerformRaycast(transform.position, leftDirection, AttackRange, out RaycastHit hitL);
    bool hitRight = PerformRaycast(transform.position, rightDirection, AttackRange, out RaycastHit hitR);
    Debug.Log(hitLeft );
    // Debug visualization
    Debug.DrawRay(transform.position, leftDirection * AttackRange, Color.red);
    Debug.DrawRay(transform.position, rightDirection * AttackRange, Color.blue);

    // Log results
    if (hitLeft && Time.time > attacktime) ChangeTOAttack(Vector2.left);
    else if (hitRight  && Time.time > attacktime) ChangeTOAttack(Vector2.right);
  }

  bool PerformRaycast(Vector3 origin, Vector3 direction, float distance, out RaycastHit hit)
  {
    return Physics.Raycast(origin, direction, out hit, distance, layerMask);
  }

  public void TakeDamege()
  {
    Health -= 1;

    if (Health <= 0)
    {
      OnDeath?.Invoke(this);
      moveTweener?.Kill();
      attacksequatnce?.Kill();
      Destroy(gameObject);
    }
     
  }

  public void HealHealth()
  {
  }
}

public enum EnemyState
{
  Idle,
  move,
  attack,
  ishit
}
