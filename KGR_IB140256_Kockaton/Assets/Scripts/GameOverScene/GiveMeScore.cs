using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GiveMeScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
