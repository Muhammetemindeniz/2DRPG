using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace pattack
{
    public class PlayerAttack : MonoBehaviour
    {
        public Transform attackPoint;
        public LayerMask enemyLayers;
        public float radius = 0.5f;
        public float attackDamage = 20;
        Animator anim;
        int attacksayýsý;

        void Start()
        {

            anim = GetComponent<Animator>();
        }
        void Update()
        {
            Attack();
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attacksayýsý = Random.Range(0, 5);
                anim.SetInteger("AttackRange", attacksayýsý);
                anim.SetTrigger("Attack");

            }
            else
            {
                anim.ResetTrigger("Attack");
            }
        }
        public void EnemyDamage()
        {
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemyLayers);
            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<EnemyC>().TakeDamage(attackDamage);
            }
        }
        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
            {
                return;
            }
            Gizmos.DrawWireSphere(attackPoint.position, radius);
        }
    }
}
