using UnityEngine;
using UnityEngine.UI;

public class SubmitScore : MonoBehaviour
{
    public InputField nicknameField;
    public Button submitBtn;
    private string username;
    private int score;
    public void OnSubmit()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        username = nicknameField.text;
        score = PlayerPrefs.GetInt("HighScore");

        HighScore.AddNewHighScore(username, score);

        submitBtn.interactable = !submitBtn.interactable;

        nicknameField.interactable = !nicknameField.interactable;
    }
}
