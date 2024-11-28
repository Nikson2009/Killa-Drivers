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
        if (!PlayerPrefs.HasKey("Sensitive"))
        {
            PlayerPrefs.SetFloat("Sensitive", 195);
        }
        SensitiveText.text = (PlayerPrefs.GetFloat("Sensitive")/195).ToString();

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
            float Sens = result * 195;
            PlayerPrefs.SetFloat("Sensitive", Sens);
        }
    }
    public void ChangeQuality(int currentQuality)
    {
        QualitySettings.SetQualityLevel(currentQuality);
        QualitySettings.renderPipeline = QualityLevels[currentQuality];
        PlayerPrefs.SetInt("Quality", currentQuality);
    }
}
