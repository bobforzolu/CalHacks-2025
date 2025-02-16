using System;
using System.Components;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public CustomAnimationEvent animationEvent;
    
    public IHealth enemyHealth;
    public int damage;
    public event Action<Vector3> OnHit;
    
    private void Start()
    {
        animationEvent.OnAniamtion += ApplyAttack;
    }

    private void OnDisable()
    {
        animationEvent.OnAniamtion -= ApplyAttack;

    }

    private void ApplyAttack(AniamtionEventType DammageTrigger)
    {
        if( DammageTrigger != AniamtionEventType.DamageTrigger) return;
        
        if(enemyHealth == null) return;
        
            enemyHealth.TakeDamege();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(transform.tag))
        {
            Debug.Log("you");
            if (other.gameObject.TryGetComponent(out IHealth health))
            {
                Debug.Log("Hit");
                enemyHealth = health;
                enemyHealth.TakeDamege();
                OnHit?.Invoke(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyHealth = null;
    }
}
