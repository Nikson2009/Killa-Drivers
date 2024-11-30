using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void OnClick()
    {
        print("Click!");
        SceneManager.LoadScene(0);
    }
}
