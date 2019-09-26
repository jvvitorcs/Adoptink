using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
   // public AudioMixer mixer;
    public void SetMusicVolume(float sliderValue)
    {
        // mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        AudioManager.instance.musicVolume = sliderValue;
    }

    public void SetSfxVolume(float sliderValue)
    {
        AudioManager.instance.sfxVolume = sliderValue;
    }
}

