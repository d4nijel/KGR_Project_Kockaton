using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    string MenuSceneName = "Menu";
    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuSceneName);
    }
}
