using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    [Header("Mechanics")]
    public GameObject menuPause, popupDificuldade, outGame;
    public float meta, time;
    public int combo, currentSceneIndex, timeToWait = 3, life = 3, points;
    int maxLife = 6;
    //private Dictionary<string, int> mapsHistoric = new Dictionary<string, int>();
    [Header("Controllers")]
    public bool pause = false, isBegin, calledWinScreen;
    public Text cronometro;
    public string mapName;
    [Header("References")]
    public List<int> score = new List<int>();
    public List<string> maps = new List<string>();      
    [SerializeField] AudioClip SoundPoint, SoundError;
    City city;
    //AudioSource myAudioSource;    

    void Start()
    {
        var LoadSave = SaveManager.Load();
        if (LoadSave != null)
        {
            score = LoadSave.score;
            maps = LoadSave.maps;
        }
        Time.timeScale = 0;
        popupDificuldade.SetActive(true);
       // myAudioSource = GetComponent<AudioSource>();
        city = FindObjectOfType<City>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isBegin = false;
        points = 0;
        meta = 2;
        life = 3;
    }

    void Update()
    {
        MudarTela();
        Life();
        PauseGame();
        TimerCount();
        Victory();
    }

    private void Victory()
    {
        if (combo == 9 && !calledWinScreen)
        {
            StartCoroutine("WinScene");
            calledWinScreen = true;
        }
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) && pause == false && isBegin)
        {
            Time.timeScale = 0;
            pause = true;
            menuPause.SetActive(true);

        }
        else

        if (Input.GetKeyDown(KeyCode.P) && pause == true && isBegin)
        {
            Time.timeScale = 1;
            pause = false;
            menuPause.SetActive(false);
        }
    }

    public void askOutGame()
    {
        if (outGame.activeSelf == true)
        {
            outGame.SetActive(false);
        } else
        {
            outGame.SetActive(true);
        }
    }
    private void MudarTela()
    {
        if (points == meta)
        {
            Invoke("Resetar", 1);
        }
    }
    void Resetar()
    {
        combo += 1;
        city.Mudar();
        meta = meta * 2;
        CancelInvoke();
    }

    void Life()
    {
        if (life > 5)
        {
            life = maxLife;
        }
        else if (life <= 0)
        {
            life = 0;
            //StartCoroutine(LoseScene());
            SceneManager.LoadScene("LoseScreen");

        }
    }
    //Está sendo chamado pelo AnimalCollision
    public void AddPoints()
    {
        //myAudioSource.PlayOneShot(SoundPoint);
        AudioManager.instance.PlaySFx(SoundPoint, false);
        points += 1;
        life += 1;

    }

    public void PlayError()
    {
        //myAudioSource.PlayOneShot(SoundError);
        AudioManager.instance.PlaySFx(SoundError, false);

    }

    IEnumerator WinScene()
    {
        SceneManage.getInstace().previousMap = mapName;
        SaveManager.Save(combo, mapName, combo);
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("WinScreen");
    }   

    void TimerCount()
    {
        time -= Time.deltaTime;
        int seconds = (int)(time % 60);
        int minutes = (int)(time / 60) % 60;

        string cronometroString = string.Format("{0:0}:{1:00}", minutes, seconds);
        cronometro.text = cronometroString;
        if (isBegin)
        {
            if (time <= 0.1)
            {
                SceneManage.getInstace().previousMap = mapName;
                SaveManager.Save(combo, mapName, combo);
                SceneManager.LoadScene("WinScreen");
                calledWinScreen = true;
            }
        }
    }

    public void SetEasy()
    {
        Time.timeScale = 1;
        popupDificuldade.SetActive(false);
        time = 900f;
        isBegin = true;
        FindObjectOfType<SpawnHumans>().dificuldade = 0;

    }

    public void SetMedium()
    {
        Time.timeScale = 1;
        popupDificuldade.SetActive(false);
        time = 840f;
        isBegin = true;
        FindObjectOfType<SpawnHumans>().dificuldade = 1;
    }
    public void SetHard()
    {
        popupDificuldade.SetActive(false);
        Time.timeScale = 1;
        time = 780f;
        isBegin = true;
        FindObjectOfType<SpawnHumans>().dificuldade = 2;
    }

    public bool isGameOver()
    {
        if (!calledWinScreen && life > 0)
            return false;
        return true;

    }

}