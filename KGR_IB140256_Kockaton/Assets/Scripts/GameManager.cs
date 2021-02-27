using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float slowness = 5f;
    public Score score;
    public int rezultat;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            StartCoroutine(RestartLevel());
        }
    }

    public void GetHighScore()
    {
        rezultat = int.Parse(score.scoreText.text);

        PlayerPrefs.SetInt("HighScore", rezultat);
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(0.5f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        GetHighScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
