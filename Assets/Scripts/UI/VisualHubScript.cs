using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualHubScript : MonoBehaviour
{
    private List<int> MaxParams = new List<int>();
    [Header("Ui instances")]
    [SerializeField] Slider Health_Slider;
    [SerializeField] Slider Oxygen_Slider;
    [SerializeField] Slider Stamina_Slider;
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
        Oxygen_Slider.value  = 1-curentHpProc;
        Oxygen_Slider.value  = 1-curentOxygenProc;
        Stamina_Slider.value = 1-curentStaminaProc;
    }
}
