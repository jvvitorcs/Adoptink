using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    public Sprite[] estrelas;
    public Image[] estrelinhaMaps, casasImagem;
    public Sprite[] casas;

    private void Start()
    {
        for (int i = 0; i < estrelinhaMaps.Length; i++)
        {
            var scoreLevel = GetScoreFromLevels(i);
            if (scoreLevel <= 3 && scoreLevel > 0)
            {
                estrelinhaMaps[i].sprite = estrelas[1];
            }
            else if (scoreLevel > 3 && scoreLevel <= 6)
            {
                estrelinhaMaps[i].sprite = estrelas[2];
            }
            else if (scoreLevel > 6 && scoreLevel <= 8)
            {
                estrelinhaMaps[i].sprite = estrelas[3];
            }
            else if (scoreLevel > 8 && scoreLevel == 9)
            {
                casasImagem[i].sprite = casas[i];
                estrelinhaMaps[i].sprite = estrelas[4];
            }
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
            }
            else
            {
                return HighScore[index];

            }

        }
        else
        {
            Debug.Log("SaveNonEcxiste");
            return 0;
        }

    }


}
