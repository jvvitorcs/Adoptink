using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public void SetMusicVolume(float sliderValue)
    {
        AudioManager.instance.musicVolume = sliderValue;
    }

    public void SetSfxVolume(float sliderValue)
    {
        AudioManager.instance.sfxVolume = sliderValue;
    }
}

