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
        //Health_Text.text = PlayerScript.GetCurrentHealth() + "%";
        Color first = new Color(1, 1, 1);
        Color second = new Color(1, 1, 1);
        Health_Text.colorGradient = new VertexGradient(first,first, second,second);
    }
}
