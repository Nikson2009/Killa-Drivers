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
    [SerializeField] TextMeshProUGUI Oxygen_Text;
    [SerializeField] TextMeshProUGUI Stamina_Text;
    [Header("Other scripts instances")]
    [SerializeField] Player PlayerScript; //mb change to another with void damage received
    private void Start()
    {
        MaxParams = PlayerScript.GetMaxParameters();//0 MaxHealth,1 Max oxygen,2 MaxStamina
    }

    private void Update()
    {
        //Curent Variables
        int curentHp = PlayerScript.GetCurrentHealth();
        int curentOxygen = PlayerScript.GetCurrentOxygenLevel();
        int curentStamina = PlayerScript.GetCurrentStamina();

        //Curent Variables in procents
        float curentHpProc = (float)curentHp / MaxParams[0];
        float curentOxygenProc = (float)curentOxygen / MaxParams[1];
        float curentStaminaProc = (float)curentStamina / MaxParams[2];

        //Changing Variable text
        Health_Text.text = curentHpProc*100 + "%";
        Oxygen_Text.text = curentOxygenProc * 100 + "%";
        Stamina_Text.text = curentStaminaProc*100 + "%";

        //Creating Gradient
        Color first = new Color((float)(MaxParams[0] - curentHp) / 100, 1, 1);
        Color second = new Color((float)(MaxParams[0] - curentHp) / MaxParams[0], curentHpProc, curentHpProc);
        Health_Text.colorGradient = new VertexGradient(first,first, second,second);
    }
}
