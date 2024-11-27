using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualHubScript : MonoBehaviour
{
    private List<int> MaxParams = new List<int>();
    [Header("Ui instances")]
    [SerializeField] TextMeshProUGUI Health_Text;
    [Header("Other scripts instances")]
    [SerializeField] Player PlayerScript; //mb change to another with void damage received
    private void Start()
    {
        MaxParams = PlayerScript.GetMaxParameters();//0 MaxHealth,1 Max oxygen,2 MaxStamina
    }

    private void Update()
    {
        int curentHp = PlayerScript.GetCurrentHealth();
        float curentHpInProc = curentHp / MaxParams[0];
        print(curentHpInProc);
        Health_Text.text = ((float)curentHp / (float)MaxParams[0])*100 + "%";
        Color first = new Color((float)(MaxParams[0] - curentHp) / 100, 1, 1);
        Color second = new Color((float)(MaxParams[0] - curentHp) / MaxParams[0], curentHpInProc, curentHpInProc);
        Health_Text.colorGradient = new VertexGradient(first,first, second,second);
    }
}
