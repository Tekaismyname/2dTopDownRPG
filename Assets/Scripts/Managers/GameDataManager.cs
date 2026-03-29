using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    [Header("Player Data")]
    public int coin = 0;
    public int health = 5;
    public int stamina = 5;

    [Header("Weapons")]
    public bool hasSword = true;
    public bool hasBow = false;
    public bool hasStaff = false;
    public string equippedWeapon = "Sword";

    [Header("Progress")]
    public int currentWave = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyLoadedData(SaveData data)
    {
        if (data == null) return;

        coin = data.coin;
        health = data.health;
        stamina = data.stamina;

        hasSword = data.hasSword;
        hasBow = data.hasBow;
        hasStaff = data.hasStaff;

        equippedWeapon = data.equippedWeapon;
        currentWave = data.currentWave;
    }

    public SaveData BuildSaveData(Transform playerTransform, string currentSceneName)
    {
        SaveData data = new SaveData();

        data.coin = coin;
        data.health = health;
        data.stamina = stamina;

        data.hasSword = hasSword;
        data.hasBow = hasBow;
        data.hasStaff = hasStaff;

        data.equippedWeapon = equippedWeapon;

        data.currentScene = currentSceneName;

        if (playerTransform != null)
        {
            data.playerPosX = playerTransform.position.x;
            data.playerPosY = playerTransform.position.y;
            data.playerPosZ = playerTransform.position.z;
        }

        data.currentWave = currentWave;

        return data;
    }
}