using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject grapePrefab;
    [SerializeField] private GameObject bossPrefab;

    [Header("Spawn Points")]
    [SerializeField] private Transform[] spawnPoints;

    public GameObject Spawn(string enemyType)
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned!");
            return null;
        }

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject prefabToSpawn = null;

        switch (enemyType.ToLower())
        {
            case "slime":
                prefabToSpawn = slimePrefab;
                break;
            case "goblin":
                prefabToSpawn = goblinPrefab;
                break;
            case "ghost":
                prefabToSpawn = ghostPrefab;
                break;
            case "skeleton":
                prefabToSpawn = skeletonPrefab;
                break;
            case "grape":
                prefabToSpawn = grapePrefab;
                break;
            case "bosss":
                prefabToSpawn = bossPrefab;
                break;
            default:
                Debug.LogWarning("Unknown enemy type: " + enemyType);
                return null;
        }

        return Instantiate(prefabToSpawn, randomSpawnPoint.position, Quaternion.identity);
    }
}