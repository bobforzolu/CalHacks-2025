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
                        enemy.Deflect(5);
                    else
                        enemy.Deflect(2);

                }
                
                if (other.gameObject.TryGetComponent(out BulletController bullet))
                {
                   bullet.Parry(movementComponent);

                }
            }
        
    }
    
    
    
}
