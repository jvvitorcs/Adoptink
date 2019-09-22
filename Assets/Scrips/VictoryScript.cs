using UnityEngine;
using UnityEngine.UI;

    public class VictoryScript : MonoBehaviour {

    public Text estrelinhaText;


    private void Start()
    {
        var LoadSave = SaveManager.Load();
        if (LoadSave != null)
        {
            var score = LoadSave.score;
            var HighScore = LoadSave.scoreMaps;
            var maps = LoadSave.maps;

            var mapIndex = maps.IndexOf(FindObjectOfType<SceneManage>().previousMap);
            estrelinhaText.text = score[mapIndex].ToString();            
        }
    }

}

