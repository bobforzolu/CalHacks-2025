using System;
using DG.Tweening;
using UnityEngine;


    public class MelleEnemy : Enemy
    {
        public BoxCollider boxCollider;
        private void Start()
        {
            
        }

        public override void Attack(Vector2 direction)
        {
            base.Attack(direction);
            attacksequatnce = DOTween.Sequence();
            
            if(direction  == Vector2.left)
                attacksequatnce.Append(transform.DOMoveX(transform.position.x + 0.5f, 1).OnComplete(() =>
                {
                    boxCollider.enabled = true;
                }));
            else if(direction == Vector2.right)
                attacksequatnce.Append(transform.DOMoveX( transform.position.x - 0.5f, 1).OnComplete(() =>
                {
                    boxCollider.enabled = true;
                }));

            
            if(direction  == Vector2.left)
                attacksequatnce.Append(transform.DOMoveX(transform.position.x  - 1.5f, 0.5f));
            else if(direction == Vector2.right)
                attacksequatnce.Append(transform.DOMoveX(transform.position.x + 1.5f, 1));

            attacksequatnce.OnComplete(() =>
            {
                boxCollider.enabled = false;
                if (direction == Vector2.left)
                    transform.DOMoveX(transform.position.x + 1.5f, 0.5f).OnComplete(() =>
                    {
                        enemyState = EnemyState.Idle;
                        
                    });
            });

        }

        public override void Death()
        {
            base.Death();
        }
    }
