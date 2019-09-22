using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    public Text[] estrelinhaMaps;

    private void Start()
    {
        for (int i = 0; i < estrelinhaMaps.Length; i++)
        {
            estrelinhaMaps[i].text = GetScoreFromLevels(i).ToString();

        }
    }

    private int GetScoreFromLevels(int index)
    {
        var LoadSave = SaveManager.Load();
        if (LoadSave != null)
        {
            var HighScore = LoadSave.scoreMaps;
            if (index > HighScore.Count - 1)
            {
                return 0;
            } else
            {                
                return HighScore[index];
                
            }               
              
        } else
        {
            Debug.Log("SaveNonEcxiste");
            return 0;
        }
       
    }


}
