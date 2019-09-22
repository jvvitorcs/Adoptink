using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null;
    //private float musicVolume;
    //public Slider Volume;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
  

    //public void SetVolume (float vol)
    //{
    //    musicVolume = vol;
    //    AudioListener.volume = Volume.value;
    //}   
}