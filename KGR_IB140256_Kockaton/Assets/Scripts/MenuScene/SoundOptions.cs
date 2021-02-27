using UnityEngine;
using UnityEngine.UI;
public class SoundOptions : MonoBehaviour
{
    public Toggle toggle;
    void Awake()
    {
        toggle.isOn = IsMuted.isMuted;
    }
    public void SetMute(bool mute)
    {
        FindObjectOfType<AudioManager>().Play("Click");

        if (!mute)
        {
            FindObjectOfType<AudioManager>().MuteOn();
            IsMuted.isMuted = false;
        }
        else
        {
            FindObjectOfType<AudioManager>().MuteOff();
            IsMuted.isMuted = true;
        }
    }
}
