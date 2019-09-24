using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManage : MonoBehaviour
{
    //[SerializeField] int timeToWait = 5;
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
                StartCoroutine(LoadScene("Fases", 1));
            }
        }
    }

    public IEnumerator LoadScene(string scene, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scene);
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
