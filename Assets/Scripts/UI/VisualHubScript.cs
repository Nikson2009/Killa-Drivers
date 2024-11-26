using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualHubScript : MonoBehaviour
{
    [Header("Ui instances")]
    [SerializeField] TextMeshProUGUI Health_Text;
    [Header("Other scripts instances")]
    [SerializeField] Player PlayerScript; //mb change to another with void damage received

    private void Update()
    {
        int curentHp = PlayerScript.GetCurrentHealth();
        Health_Text.text = curentHp + "%";
        Color first;
        first = new Color((float)(100 - curentHp) / 100, 1, 1);
        Color second = new Color((float)(100 - curentHp) / 100, (float) curentHp/100, (float)curentHp/100);
        Health_Text.colorGradient = new VertexGradient(first,first, second,second);
    }
}
