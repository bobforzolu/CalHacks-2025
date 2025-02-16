using DG.Tweening;
using UnityEngine;


    public class MelleEnemy : Enemy
    {
        public override void Attack(Vector2 direction)
        {
            base.Attack(direction);
            attacksequatnce = DOTween.Sequence();
            
            if(direction  == Vector2.left)
                attacksequatnce.Append(transform.DOMoveX(transform.position.x + 0.5f, 1));
            else if(direction == Vector2.right)
                attacksequatnce.Append(transform.DOMoveX( transform.position.x - 0.5f, 1));

            
            if(direction  == Vector2.left)
                attacksequatnce.Append(transform.DOMoveX(transform.position.x  - 1.5f, 0.5f));
            else if(direction == Vector2.right)
                attacksequatnce.Append(transform.DOMoveX(transform.position.x + 1.5f, 1));

            attacksequatnce.Play();
        }

        public override void Death()
        {
            base.Death();
        }
    }
