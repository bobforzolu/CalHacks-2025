using System;
using System.Components;
using UnityEngine;

public class BulletController : MonoBehaviour
{
        public int speed;

        public int damage;
        public bool targetPlayer;


        private void Start()
        {
                targetPlayer = true;
        }

        public void Shoot(Vector2 direction)
        { 
                GetComponent<Rigidbody>().AddForce(( direction) * speed, ForceMode.Impulse);

        }

        public void Parry(MovementComponent movement)
        {
                targetPlayer = false;
                GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                
                GetComponent<Rigidbody>().AddForce((movement.facingDirections * Vector2.right) * speed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
                if (targetPlayer)
                {
                        if (!other.gameObject.CompareTag("Player")) return;
                        if (!other.TryGetComponent(out IHealth health)) return;
                         health.TakeDamege();
                        Destroy(gameObject);
                }
                else if(!targetPlayer)
                {
                        if (!other.gameObject.CompareTag("Enemy")) return;
                        if (!other.TryGetComponent(out IHealth health)) return;
                                health.TakeDamege();
                        Destroy(gameObject);

                }
        }
        
        
}
