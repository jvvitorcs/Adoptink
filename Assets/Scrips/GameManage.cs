using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    //private Dictionary<string, int> mapsHistoric = new Dictionary<string, int>();
    public List<int> score = new List<int>();
    public List<string> maps = new List<string>();
    public GameObject menuPause, popupDificuldade;
    public float meta, time;
    public int combo, currentSceneIndex, timeToWait = 3, life, points;
    public bool pause = false, isBegin, calledWinScreen;
    SpawnHumans SH;
    SceneManage SM;
    City city;
    int maxLife = 6;
    [SerializeField] AudioClip SoundPoint, SoundError;
    AudioSource myAudioSource;
    public Text cronometro;
    public string mapName;

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
        myAudioSource = GetComponent<AudioSource>();
        SM = FindObjectOfType<SceneManage>();
        city = FindObjectOfType<City>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isBegin = false;
        points = 0;
        meta = 5;
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
        if (combo == 5 && !calledWinScreen)
        {
            StartCoroutine("WinScene");
            calledWinScreen = true;
        }
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) && pause == false)
        {
            Time.timeScale = 0;
            pause = true;
            menuPause.SetActive(true);

        } else

        if (Input.GetKeyDown(KeyCode.P) && pause == true)
        {
            Time.timeScale = 1;
            pause = false;
            menuPause.SetActive(false);
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
            StartCoroutine(LoseScene());
        }
    }
    //Está sendo chamado pelo AnimalCollision
    public void AddPoints(){
        myAudioSource.PlayOneShot(SoundPoint);
        points += 1;
        life += 1;

    }

    public void PlayError()
    {
        myAudioSource.PlayOneShot(SoundError);

    }

    IEnumerator WinScene()
    {
        
        FindObjectOfType<SceneManage>().previousMap = mapName;
        SaveManager.Save(combo, mapName, combo);
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("WinScreen");
    }

    IEnumerator LoseScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LoseScreen");
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
            if (time <= 0)
            {
                //salvar aqui tambem;
                FindObjectOfType<SceneManage>().previousMap = mapName;
                SaveManager.Save(combo, mapName, combo);
                SceneManager.LoadScene("WinScreen");               
            }
        }
    }

    public void SetEasy()
    {
        Time.timeScale = 1;
        popupDificuldade.SetActive(false);

        time = 120f;
        isBegin = true;

    }

    public void SetMedium()
    {
        Time.timeScale = 1;
        popupDificuldade.SetActive(false);

        time = 60f;
        isBegin = true;

    }
    public void SetHard()
    {
        popupDificuldade.SetActive(false);
        Time.timeScale = 1;
        time = 30f;
        isBegin = true;
    }

    

}