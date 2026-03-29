using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class WaveData
    {
        public int slimeCount;
        public int goblinCount;
        public int ghostCount;
        public int skeletonCount;
        public int grapeCount;
        public int bossCount;
    }

    [Header("Wave Settings")]
    [SerializeField] private List<WaveData> waves = new List<WaveData>();
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private float timeBetweenSpawns = 0.5f;

    [Header("References")]
    [SerializeField] private EnemySpawner enemySpawner;

    private int currentWaveIndex = -1;
    private int enemiesAlive = 0;
    private bool isSpawningWave = false;

    private void Start()
    {
        StartCoroutine(BeginNextWave());
    }

    private IEnumerator BeginNextWave()
    {
        if (isSpawningWave) yield break;
        isSpawningWave = true;

        yield return new WaitForSeconds(timeBetweenWaves);

        currentWaveIndex++;

        if (currentWaveIndex >= waves.Count)
        {
            Debug.Log("All waves completed!");

            VictoryUI victoryUI = FindObjectOfType<VictoryUI>();
            if (victoryUI != null)
            {
                victoryUI.ShowVictory();
            }

            yield break;
        }

        WaveData wave = waves[currentWaveIndex];
        Debug.Log($"Starting Wave {currentWaveIndex + 1}");

        yield return StartCoroutine(SpawnEnemies("slime", wave.slimeCount));
        yield return StartCoroutine(SpawnEnemies("goblin", wave.goblinCount));
        yield return StartCoroutine(SpawnEnemies("ghost", wave.ghostCount));
        yield return StartCoroutine(SpawnEnemies("skeleton", wave.skeletonCount));

        isSpawningWave = false;
    }

    private IEnumerator SpawnEnemies(string enemyType, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = enemySpawner.Spawn(enemyType);

            if (enemy != null)
            {
                enemiesAlive++;

                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.SetWaveManager(this);
                }
            }

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void NotifyEnemyKilled()
    {
        enemiesAlive--;
        Debug.Log("Enemies alive: " + enemiesAlive);

        if (enemiesAlive <= 0 && !isSpawningWave)
        {
            StartCoroutine(BeginNextWave());
        }
    }
}