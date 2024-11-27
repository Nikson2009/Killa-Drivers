using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualHubScript : MonoBehaviour
{
    [SerializeField]private int PlayerMaxHealth = 100;
    [Header("Ui instances")]
    [SerializeField] TextMeshProUGUI Health_Text;
    [Header("Other scripts instances")]
    [SerializeField] Player PlayerScript; //mb change to another with void damage received
    private void Start()
    {
        PlayerMaxHealth = PlayerScript.GetCurrentMaxHealth();
    }

    private void Update()
    {
        int curentHp = PlayerScript.GetCurrentHealth();
        Health_Text.text = ((float)curentHp / (float)PlayerMaxHealth)*100 + "%";
        Color first;
        first = new Color((float)(PlayerMaxHealth - curentHp) / 100, 1, 1);
        Color second = new Color((float)(PlayerMaxHealth - curentHp) / PlayerMaxHealth, (float) curentHp/ PlayerMaxHealth, (float)curentHp/ PlayerMaxHealth);
        Health_Text.colorGradient = new VertexGradient(first,first, second,second);
    }
}
