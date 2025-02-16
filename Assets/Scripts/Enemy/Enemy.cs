using System;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float AttackRange;
  public float AttackCoolDown;
  public float MovementSpeed;
  public EnemyState enemyState;
  public LayerMask layerMask;
  
  [Header("Attack")]
  public float TimeBetweenAttacks;
  public float attacktime;
  
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
  
private void Awake()
{
  Spawn();
}

public virtual void Spawn()
  {
    SetMovement();
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
    moveTweener = transform.DOMoveX(tartget.transform.position.x, 1).SetSpeedBased().SetEase(Ease.Linear);

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
    CheckLeftRightRaycast();
    
    
    switch (enemyState)
    {
      case EnemyState.Idle:
        break;
      case EnemyState.move:
        break;
      case EnemyState.attack:
        break;
      case EnemyState.ishit:
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
}

public enum EnemyState
{
  Idle,
  move,
  attack,
  ishit
}
