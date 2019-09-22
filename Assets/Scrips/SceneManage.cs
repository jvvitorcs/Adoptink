using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManage : MonoBehaviour
{
    [SerializeField] int timeToWait = 5;
    int currentSceneIndex;
    public Text teclaTexto;
    //public bool continuar;
    public string previousMap;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadNextScene();
                //continuar = false;
            }
        }
    }

    //IEnumerator WaitAndLoad()
    //{
    //    yield return new WaitForSeconds(timeToWait);
    //    teclaTexto.text = "Pressione espaço para Continuar";
    //    continuar = true;
    //}


    public void LoadNextScene()
    {
        //configs.SetActive(false);
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        //configs.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Win()
    {
        //configs.SetActive(false);
        SaveManager.Load();
        SceneManager.LoadScene("WinScreen");
    }

    public void Lose()
    {
        //configs.SetActive(false);
        SceneManager.LoadScene("LoseScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TrocarCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }

    

    
}
