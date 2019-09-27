using UnityEngine;
using UnityEngine.UI;

    public class VictoryScript : MonoBehaviour {


    public Sprite[] estrelasSprite;
    public Image[] estrelinhasCenaVitoria;    

    private void Start()
    {
        for (int i = 0; i < estrelinhasCenaVitoria.Length; i++)
        {
            var scoreLevel = GetScoreFromLevels(i);
            if (scoreLevel <= 3 && scoreLevel > 0)
            {
                estrelinhasCenaVitoria[i].sprite = estrelasSprite[1];
            }
            else if (scoreLevel > 3 && scoreLevel <= 6)
            {
                estrelinhasCenaVitoria[i].sprite = estrelasSprite[2];
            }
            else if (scoreLevel > 6 && scoreLevel <= 8)
            {
                estrelinhasCenaVitoria[i].sprite = estrelasSprite[3];
            }
            else if (scoreLevel > 8 && scoreLevel == 9)
            {                
                estrelinhasCenaVitoria[i].sprite = estrelasSprite[4];
            }
        }

    }

    private int GetScoreFromLevels(int index)
    {
        var LoadSave = SaveManager.Load();
        if (LoadSave != null)
        {
            var scoreLevel = LoadSave.score;
            if (index > scoreLevel.Count - 1)
            {
                return 0;
            }
            else
            {
                return scoreLevel[index];

            }

        }
        else
        {           
            return 0;
        }
    }
}

