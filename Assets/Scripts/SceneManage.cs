using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManage : MonoBehaviour
{
    int currentSceneIndex;
    public string previousMap; 
    private static SceneManage instance;  

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(LoadScene("Menu", 1));
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

    public static SceneManage getInstace()
    {
        if (instance == null)
        {
            instance = new GameObject().AddComponent<SceneManage>();
        }

        return instance;
    }

    public void ResetarJogo()
    {
        SaveManager.DeleteSave();

    }
}
