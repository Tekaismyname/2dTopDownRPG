using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour, IEnemy
{
    [SerializeField] private int damage = 1;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        // Trigger attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
            Debug.Log("Attack Animation Has Been played " + this.gameObject);
        }

        // Only apply melee damage if player is in attack range (prevent friendly fire)
        float attackRadius = 1.0f; // adjust to fit your attack range in scene
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(damage, transform);
                Debug.Log("Enemy melee hits Player " + hit.gameObject.name);
                break; // one hit per attack
            }
        }

        Debug.Log("Enemy attacks!");
    }
}