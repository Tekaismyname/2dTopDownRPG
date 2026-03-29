using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackthrust = 15f;
    [SerializeField] private float deathAnimationDuration = 0.8f; // điều chỉnh theo clip

    private int currentHealth;
    private KnockBack knockBack;
    private Flash flash;
    private Animator animator;

    private WaveManager waveManager;
    private bool hasReportedDeath = false;
    private bool isDead = false;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        knockBack.GetKnockedBack(PlayerController.Instance.transform, knockBackthrust);
        StartCoroutine(flash.FlashRoutine());

        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }

        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (isDead) return;

        if (currentHealth <= 0)
        {
            isDead = true;

            if (!hasReportedDeath)
            {
                hasReportedDeath = true;

                if (waveManager != null)
                {
                    waveManager.NotifyEnemyKilled();
                }
            }

            if (animator != null)
            {
                animator.SetTrigger("Death");
            }

            StartCoroutine(HandleDeathRoutine());
        }
    }

    private IEnumerator HandleDeathRoutine()
    {
        yield return new WaitForSeconds(deathAnimationDuration);

        if (deathVFXPrefab != null)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        }

        GetComponent<PickupSpawner>()?.DropItems();
        Destroy(gameObject);
    }
}