using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualHubScript : MonoBehaviour
{
    [SerializeField] Dictionary<string,int> MaxParams;
    [Header("Ui instances")]
    [SerializeField] TextMeshProUGUI Health_Text;
    [Header("Other scripts instances")]
    [SerializeField] Player PlayerScript; //mb change to another with void damage received
    private void Start()
    {
        List<int> Max = PlayerScript.GetMaxParameters();
        print(Max[0]);
        MaxParams.Add("maxHealth", Max[0]);
        MaxParams.Add("maxOxygenLevel", Max[1]);
        MaxParams.Add("maxStamina", Max[2]);
    }

    private void Update()
    {
        int curentHp = PlayerScript.GetCurrentHealth();
        float curentHpInProc = curentHp / MaxParams["maxHealth"];
        print(curentHpInProc);
        Health_Text.text = ((float)curentHp / (float)MaxParams["maxHealth"])*100 + "%";
        Color first = new Color((float)(MaxParams["maxHealth"] - curentHp) / 100, 1, 1);
        Color second = new Color((float)(MaxParams["maxHealth"] - curentHp) / MaxParams["maxHealth"], (float) curentHp/ MaxParams["maxHealth"], (float)curentHp/ MaxParams["maxHealth"]);
        Health_Text.colorGradient = new VertexGradient(first,first, second,second);
    }
}
