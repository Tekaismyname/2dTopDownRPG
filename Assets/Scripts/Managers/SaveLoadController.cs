using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadController : MonoBehaviour
{
    public static SaveLoadController Instance;

    private SaveData pendingLoadData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveCurrentGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        string currentSceneName = SceneManager.GetActiveScene().name;
        Transform playerTransform = player != null ? player.transform : null;

        SaveData data = GameDataManager.Instance.BuildSaveData(playerTransform, currentSceneName);
        SaveManager.SaveGame(data);
    }

    public void ContinueGame()
    {
        SaveData data = SaveManager.LoadGame();
        if (data == null) return;

        pendingLoadData = data;

        if (GameDataManager.Instance != null)
        {
            GameDataManager.Instance.ApplyLoadedData(data);
        }

        SceneManager.LoadScene(data.currentScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (pendingLoadData == null) return;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(
                pendingLoadData.playerPosX,
                pendingLoadData.playerPosY,
                pendingLoadData.playerPosZ
            );
        }

        pendingLoadData = null;
    }
}