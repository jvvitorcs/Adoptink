using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



    public class AudioManager : MonoBehaviour
    {

        public static AudioManager instance;
        [Header("SoundVariables")]
        public float musicVolume;
        public float sfxVolume;
        public List<AudioManagerComponent> musicSorce = new List<AudioManagerComponent>();
        public List<AudioManagerComponent> sfxSorce = new List<AudioManagerComponent>();
        private float transitionMusicVolume;
        public bool isInTransition = false;

        private void Awake()
        {
            
            if (instance == null)
            {
                  DontDestroyOnLoad(gameObject);
                  instance = this;
            }
            else
            {
                Destroy(gameObject);
            }



        }
        private void Update()
        {


        }

        public void PlayMusic(AudioClip music, bool isLoop, Action action)
        {

            if (musicSorce.Count > 0)
            {
                for (int i = 0; i < musicSorce.Count; i++)
                {

                    if (musicSorce[i].GetComponent<AudioSource>() && musicSorce[i].GetComponent<AudioSource>().clip != null && musicSorce[i].GetComponent<AudioSource>().clip == music)
                    {
                        Debug.Log("this clip is already in List and is playing");
                        return;

                    }
                }

            }
            GameObject audioGO = new GameObject();
            audioGO.transform.parent = this.transform;
            audioGO.transform.name = music.name;
            audioGO.AddComponent<AudioManagerComponent>();
            audioGO.GetComponent<AudioManagerComponent>().Inicialization(this, isLoop, music, musicVolume, true);
            musicSorce.Add(audioGO.GetComponent<AudioManagerComponent>());

        }

        public void PlayMusic(AudioClip music, bool isLoop)
        {

            if (musicSorce.Count > 0)
            {
                for (int i = 0; i < musicSorce.Count; i++)
                {
                    if (musicSorce[i].GetComponent<AudioSource>() && musicSorce[i].GetComponent<AudioSource>().clip != null && musicSorce[i].GetComponent<AudioSource>().clip == music)
                    {
                        Debug.Log("this clip is already in List and is playing");
                        return;

                    }
                }

            }
            GameObject audioGO = new GameObject();
            audioGO.transform.parent = this.transform;
            audioGO.transform.name = music.name;
            audioGO.AddComponent<AudioManagerComponent>();
            audioGO.GetComponent<AudioManagerComponent>().Inicialization(this, isLoop, music, musicVolume, true);
            musicSorce.Add(audioGO.GetComponent<AudioManagerComponent>());

        }
        public void TransitionMusic(AudioClip music, int transitionLenght)
        {

            StartCoroutine(Transition(music, transitionLenght));


        }
        private IEnumerator Transition(AudioClip music, int transitionLenght)
        {

            transitionMusicVolume = musicVolume;
            isInTransition = true;
            while (isInTransition)
            {
                musicVolume -= Time.deltaTime;
                if (musicVolume <= transitionMusicVolume / transitionLenght)
                {
                    isInTransition = false;
                    RemoveMusic(musicSorce); //TODO: HARDCODE
                    PlayMusic(music, true);
                }
                yield return new WaitForSeconds(.1f);

            }
            StartCoroutine(FadeIn());

        }
        private IEnumerator FadeIn()
        {

            isInTransition = true;
            while (isInTransition)
            {
                musicVolume += Time.deltaTime;
                if (musicVolume >= transitionMusicVolume)
                {
                    isInTransition = false;
                    transitionMusicVolume = 0;
                }
                yield return new WaitForSeconds(.1f);

            }

        }
        public void PlaySFx(AudioClip music, bool isLoop)
        {


            GameObject audioGO = new GameObject();
            audioGO.transform.parent = this.transform;
            audioGO.transform.name = music.name;
            audioGO.AddComponent<AudioManagerComponent>();
            audioGO.GetComponent<AudioManagerComponent>().Inicialization(this, isLoop, music, musicVolume, false);
            sfxSorce.Add(audioGO.GetComponent<AudioManagerComponent>());

        }
        public void PlaySFx(AudioClip music, bool isLoop, Action action)
        {


            GameObject audioGO = new GameObject();
            audioGO.transform.parent = this.transform;
            audioGO.transform.name = music.name;
            audioGO.AddComponent<AudioManagerComponent>();
            audioGO.GetComponent<AudioManagerComponent>().Inicialization(this, isLoop, music, musicVolume, action, false);
            sfxSorce.Add(audioGO.GetComponent<AudioManagerComponent>());

        }
        public void RemoveMusic(AudioManagerComponent AudioManagerToRemove)
        {
            musicSorce.Remove(AudioManagerToRemove);
            Destroy(AudioManagerToRemove.gameObject);
        }
        public void RemoveMusic(List<AudioManagerComponent> AudioManagerListToRemove)
        {
            for (int i = 0; i < AudioManagerListToRemove.Count; i++)
            {
                GameObject objToDestoy = AudioManagerListToRemove[i].gameObject;
                musicSorce.Remove(AudioManagerListToRemove[i]);
                Destroy(objToDestoy);
            }

        }
        public void RemoveSfx(AudioManagerComponent AudioManagerToRemove)
        {

            sfxSorce.Remove(AudioManagerToRemove);
            Destroy(AudioManagerToRemove.gameObject);
        }


    }
    [RequireComponent(typeof(AudioSource))]
    public class AudioManagerComponent : MonoBehaviour
    {
        public void Inicialization(AudioManager audioManager, bool isLoop, AudioClip clip, float volume, bool isMusic)
        {

            audioSorce = GetComponent<AudioSource>();
            this.audioManager = audioManager;
            audioSorce.loop = isLoop;
            audioSorce.clip = clip;
            audioSorce.playOnAwake = false;
            audioSorce.volume = volume;
            this.isMusic = isMusic;
            audioSorce.Play();
        }
        public void Inicialization(AudioManager audioManager, bool isLoop, AudioClip clip, float volume, Action action, bool isMusic)
        {

            audioSorce = GetComponent<AudioSource>();
            this.audioManager = audioManager;
            audioSorce.loop = isLoop;
            audioSorce.clip = clip;
            audioSorce.playOnAwake = false;

            audioSorce.volume = volume;
            this.action = action;
            this.isMusic = isMusic;
            audioSorce.Play();
        }
        private AudioManager audioManager;
        private AudioSource audioSorce;
        private Action action;
        private bool isMusic;
        public AudioSource GetAudioSource() { return audioSorce; }

        private void Update()
        {

            if (isMusic)
            {

                if (audioSorce.volume != audioManager.musicVolume)
                {
                    audioSorce.volume = audioManager.musicVolume;

                }

            }
            else
            {
                if (audioSorce.volume != audioManager.sfxVolume)
                {
                    audioSorce.volume = audioManager.sfxVolume;

                }

            }


            // when a sound end
            if (!audioSorce.isPlaying)
            {


                if (action != null)
                {

                    action();
                }
                if (isMusic)
                {
                    audioManager.RemoveMusic(this);

                }
                else
                {

                    audioManager.RemoveSfx(this);

                }



            }

        }
    }
