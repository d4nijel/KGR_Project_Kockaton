using UnityEngine;
public class Difficulty : MonoBehaviour
{
    private int difficulty = 1;
    private int maxDifficulty = 10;
    private float scoreToNextLevel = 500f;
    public PlayerMovement movement;

    void FixedUpdate()
    {
        if (transform.position.z > scoreToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        if (difficulty == maxDifficulty)
        {
            return;
        }
        scoreToNextLevel += 500f;

        FindObjectOfType<AudioManager>().Play("Checkpoint");

        GetComponent<PlayerMovement>().SetSpeed(difficulty * 6);
        difficulty++;

    }
}
