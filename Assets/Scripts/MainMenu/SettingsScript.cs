using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    [Header("Sensitive")]
    [SerializeField] TMP_InputField SensitiveText;
    [Header("Quality")]
    [SerializeField] TMP_Dropdown QualityDropdown;
    [SerializeField] RenderPipelineAsset[] QualityLevels;
    [Header("Sounds")]
    [SerializeField] AudioMixer MixerBG;
    [SerializeField] Slider SliderBG;
    [SerializeField] AudioMixer MixerSFX;
    [SerializeField] Slider SliderSFX;
    [Header("In Game Options")]
    [SerializeField] CameraRotation CR;
    private bool isSetUpped = false;
    private bool isInGame = false;
    private void Start()
    {
        //Set up sensive
        if (!PlayerPrefs.HasKey("Sensitive")) {PlayerPrefs.SetFloat("Sensitive", 195); }
        SensitiveText.text = (PlayerPrefs.GetFloat("Sensitive")/195).ToString();

        //Set up quality
        int currentQuality = PlayerPrefs.GetInt("Quality");
        QualityDropdown.value = currentQuality;
        QualitySettings.SetQualityLevel(currentQuality);
        QualitySettings.renderPipeline = QualityLevels[currentQuality];

        //Set up sounds
        if (!PlayerPrefs.HasKey("BackgroundVolume")) { PlayerPrefs.SetFloat("BackgroundVolume", 0.8f); }
        float Volume = PlayerPrefs.GetFloat("BackgroundVolume");
        MixerBG.SetFloat("Master Volume", (Volume * 100) - 80);
        SliderBG.value = Volume;

        if (!PlayerPrefs.HasKey("SFXVolume")) { PlayerPrefs.SetFloat("SFXVolume", 0.8f); }
        float SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        MixerSFX.SetFloat("Master Volume", (SFXVolume * 100) - 80);
        SliderSFX.value = SFXVolume;

        //Complete Set Up
        isInGame = SceneManager.GetActiveScene().buildIndex != 0;
        isSetUpped = true;
    }
    public void ChangeSensitive(TMP_InputField text)
    {
        if (float.TryParse(text.text,out float result))
        {
            float Sens = result * 195;
            PlayerPrefs.SetFloat("Sensitive", Sens);
            if (isInGame)
            {
                CR.sensetivityX = Sens;

                CR.sensetivityY = Sens;
            }
        }
    }
    public void ChangeQuality(int currentQuality)
    {
        QualitySettings.SetQualityLevel(currentQuality);
        QualitySettings.renderPipeline = QualityLevels[currentQuality];
        PlayerPrefs.SetInt("Quality", currentQuality);
    }
    public void ChangeBackgroundVolume(float value)
    {
        if (isSetUpped)
        {
            PlayerPrefs.SetFloat("BackgroundVolume", value);
            MixerBG.SetFloat("Master Volume", (value * 100) - 80);
        }
    }
    public void ChangeSFXVolume(float value)
    {
        if (isSetUpped)
        {
            PlayerPrefs.SetFloat("SFXVolume", value);
            MixerSFX.SetFloat("Master Volume", (value * 100) - 80);
        }
    }
}
