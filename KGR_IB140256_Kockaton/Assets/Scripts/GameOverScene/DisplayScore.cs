using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text[] highscoreText;
    HighScore highscoreManager;

    void Start()
    {

        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Fetching...";
        }

        highscoreManager = GetComponent<HighScore>();

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighScoresDownloaded(HighScore.Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }
    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoreManager.DownloadHighsScores();
            yield return new WaitForSeconds(30);
        }
    }
}
