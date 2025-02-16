using UnityEngine;


    public class RangedEnemy : Enemy
    {
        public GameObject Projectile;
        public override void Attack(Vector2 direction)
        {
            base.Attack(direction);
            GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
            if (direction == Vector2.left)
            {
                projectile.GetComponent<BulletController>().Shoot(Vector2.left);

            }
            else
            {
                projectile.GetComponent<BulletController>().Shoot(Vector2.right);
    
            }
            
            isAttacking = false;
            idleTime = idleDuration + Time.time;
            enemyState = EnemyState.Idle;

        }

        public override void Death()
        {
            base.Death();
        }
    }
