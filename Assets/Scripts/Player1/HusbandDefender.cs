using System;
using System.Components;
using UnityEngine;

public class HusbandDefender : MonoBehaviour
{
    public MovementComponent movementComponent;
    private void OnTriggerEnter(Collider other)
    {
      
            if (!other.gameObject.CompareTag(transform.tag))
            {
                Debug.Log("you");
                if (other.gameObject.TryGetComponent(out Enemy enemy))
                {
                    if(enemy.isAttacking)
                        enemy.IsHit(new Vector2(movementComponent.facingDirections, 1) * 3);
                    else
                        enemy.IsHit((Vector2.right *  movementComponent.facingDirections) * 2);

                }
                
                if (other.gameObject.TryGetComponent(out BulletController bullet))
                {
                   bullet.Parry(movementComponent);

                }
            }
        
    }
    
    
    
}
