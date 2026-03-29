using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMP_Text musicValueText;
    [SerializeField] private TMP_Text sfxValueText;

    [Header("Display")]
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions = new List<Resolution>();

    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";
    private const string FullscreenKey = "Fullscreen";
    private const string ResolutionIndexKey = "ResolutionIndex";
    private const string QualityKey = "QualityLevel";

    private void Start()
    {
        SetupResolutionDropdown();
        SetupQualityDropdown();
        LoadSettings();
    }

    private void SetupResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        filteredResolutions.Clear();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        HashSet<string> added = new HashSet<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            if (!added.Contains(option))
            {
                added.Add(option);
                filteredResolutions.Add(resolutions[i]);
                options.Add(option);
            }
        }

        resolutionDropdown.AddOptions(options);
    }

    private void SetupQualityDropdown()
    {
        qualityDropdown.ClearOptions();
        List<string> qualityOptions = new List<string>(QualitySettings.names);
        qualityDropdown.AddOptions(qualityOptions);
    }

    private void LoadSettings()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicKey, 1f);
        float savedSfxVolume = PlayerPrefs.GetFloat(SFXKey, 1f);
        int savedFullscreen = PlayerPrefs.GetInt(FullscreenKey, 1);
        int savedQuality = PlayerPrefs.GetInt(QualityKey, QualitySettings.GetQualityLevel());
        int savedResolutionIndex = PlayerPrefs.GetInt(ResolutionIndexKey, GetDefaultResolutionIndex());

        if (musicSlider != null) musicSlider.value = savedMusicVolume;
        if (sfxSlider != null) sfxSlider.value = savedSfxVolume;

        UpdateMusicText(savedMusicVolume);
        UpdateSFXText(savedSfxVolume);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMusicVolume(savedMusicVolume);
            AudioManager.Instance.SetSFXVolume(savedSfxVolume);
        }

        bool isFullscreen = savedFullscreen == 1;
        Screen.fullScreen = isFullscreen;
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = isFullscreen;
        }

        QualitySettings.SetQualityLevel(savedQuality);
        if (qualityDropdown != null)
        {
            qualityDropdown.value = savedQuality;
            qualityDropdown.RefreshShownValue();
        }

        if (resolutionDropdown != null && filteredResolutions.Count > 0)
        {
            savedResolutionIndex = Mathf.Clamp(savedResolutionIndex, 0, filteredResolutions.Count - 1);
            resolutionDropdown.value = savedResolutionIndex;
            resolutionDropdown.RefreshShownValue();

            ApplyResolution(savedResolutionIndex);
        }
    }

    private int GetDefaultResolutionIndex()
    {
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            if (filteredResolutions[i].width == Screen.currentResolution.width &&
                filteredResolutions[i].height == Screen.currentResolution.height)
            {
                return i;
            }
        }

        return filteredResolutions.Count - 1 >= 0 ? filteredResolutions.Count - 1 : 0;
    }

    public void OnMusicSliderChanged(float value)
    {
        PlayerPrefs.SetFloat(MusicKey, value);
        PlayerPrefs.Save();

        UpdateMusicText(value);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMusicVolume(value);
        }
    }

    public void OnSFXSliderChanged(float value)
    {
        PlayerPrefs.SetFloat(SFXKey, value);
        PlayerPrefs.Save();

        UpdateSFXText(value);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetSFXVolume(value);
        }
    }

    public void OnFullscreenToggleChanged(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt(FullscreenKey, isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void OnResolutionChanged(int resolutionIndex)
    {
        ApplyResolution(resolutionIndex);
        PlayerPrefs.SetInt(ResolutionIndexKey, resolutionIndex);
        PlayerPrefs.Save();
    }

    public void OnQualityChanged(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt(QualityKey, qualityIndex);
        PlayerPrefs.Save();
    }

    private void ApplyResolution(int resolutionIndex)
    {
        if (filteredResolutions.Count == 0) return;

        resolutionIndex = Mathf.Clamp(resolutionIndex, 0, filteredResolutions.Count - 1);
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void UpdateMusicText(float value)
    {
        if (musicValueText != null)
        {
            musicValueText.text = Mathf.RoundToInt(value * 100) + "%";
        }
    }

    private void UpdateSFXText(float value)
    {
        if (sfxValueText != null)
        {
            sfxValueText.text = Mathf.RoundToInt(value * 100) + "%";
        }
    }
}