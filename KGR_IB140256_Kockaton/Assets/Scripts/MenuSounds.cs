using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public void PlayMenuSound()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
    }

    public void PlayClickSound()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
