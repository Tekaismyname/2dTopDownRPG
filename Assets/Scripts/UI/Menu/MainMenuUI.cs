using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject settingsPanel;

    [Header("Buttons")]
    [SerializeField] private Button continueButton;

    [Header("Scene Names")]
    [SerializeField] private string firstLevelSceneName = "Scene1";

    private void Start()
    {
        if (continueButton != null)
        {
            continueButton.interactable = SaveManager.SaveExists();
        }
    }

    public void ContinueGame()
    {
        if (SaveLoadController.Instance != null && SaveManager.SaveExists())
        {
            Time.timeScale = 1f;
            SaveLoadController.Instance.ContinueGame();
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;

        if (GameDataManager.Instance != null)
        {
            GameDataManager.Instance.coin = 0;
            GameDataManager.Instance.health = 5;
            GameDataManager.Instance.stamina = 5;

            GameDataManager.Instance.hasSword = true;
            GameDataManager.Instance.hasBow = false;
            GameDataManager.Instance.hasStaff = false;

            GameDataManager.Instance.equippedWeapon = "Sword";
            GameDataManager.Instance.currentWave = 1;
        }

        SceneManager.LoadScene(firstLevelSceneName);
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}