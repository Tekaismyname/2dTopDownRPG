using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private KnockBack knockBack;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(knockBack.GettingKnockedBack) { return; }
        // set rigibody movement with direction and movespeed variable
        rb.MovePosition(rb.position + moveDir * (moveSpeed* Time.fixedDeltaTime)); 

        
        if(moveDir.x < 0){
            spriteRenderer.flipX = true;
        }else if(moveDir.x > 0){
            spriteRenderer.flipX = false;
        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = (targetPosition - (Vector2)transform.position).normalized;
        // set animation walking state
        if (animator != null)
        {
            animator.SetBool("IsWalking", true);
        }

    }

    public void StopMoving(){
        moveDir = Vector3.zero;
        animator.SetBool("IsWalking", false);
    }
}
