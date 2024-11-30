using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreenManager : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
