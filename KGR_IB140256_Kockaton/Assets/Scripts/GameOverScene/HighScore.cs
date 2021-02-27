using System.Collections;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private string privateCode = "1RbOHDKAzUa1xFGIJFZE4wGeCK0zMskkWn4vdFvxXJtA";
    private string publicCode = "5b070e19191a850bcc2a699d";
    private string webURL = "http://dreamlo.com/lb/";

    DisplayScore highscoresDisplay;
    public Highscore[] highScoresList;
    static HighScore instance;
    public class Highscore
    {
        public string username;
        public int score;
        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }
    void Awake()
    {
        instance = this;
        highscoresDisplay = GetComponent<DisplayScore>();
    }
    public static void AddNewHighScore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighScore(username, score));
    }
    IEnumerator UploadNewHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload Successful");
            DownloadHighsScores();
        }
        else
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }

    public void DownloadHighsScores()
    {
        StartCoroutine("DownloadHighScoreFromDatabase");
    }
    IEnumerator DownloadHighScoreFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScore(www.text);
            highscoresDisplay.OnHighScoresDownloaded(highScoresList);
        }
        else
        {
            Debug.Log("Error Downloading: " + www.error);
        }
    }

    void FormatHighScore(string text)
    {
        string[] entries = text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highScoresList = new Highscore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highScoresList[i] = new Highscore(username, score);
        }
    }
}
