using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class SettingsScript : MonoBehaviour
{
    [Header("Sensitive")]
    [SerializeField] TMP_InputField SensitiveText;
    [Header("Quality")]
    [SerializeField] TMP_Dropdown QualityDropdown;
    [SerializeField] RenderPipelineAsset[] QualityLevels;
    private void Start()
    {
        //Set up sensive
        SensitiveText.text = PlayerPrefs.GetFloat("Sensitive").ToString();

        //Set up quality
        int currentQuality = PlayerPrefs.GetInt("Quality");
        QualityDropdown.value = currentQuality;
        QualitySettings.SetQualityLevel(currentQuality);
        QualitySettings.renderPipeline = QualityLevels[currentQuality];

    }
    public void ChangeSensitive(TMP_InputField text)
    {
        if (float.TryParse(text.text,out float result))
        {
            PlayerPrefs.SetFloat("Sensitive", result);
        }
    }
    public void ChangeQuality(int currentQuality)
    {
        QualitySettings.SetQualityLevel(currentQuality);
        QualitySettings.renderPipeline = QualityLevels[currentQuality];
        PlayerPrefs.SetInt("Quality", currentQuality);
    }
}
