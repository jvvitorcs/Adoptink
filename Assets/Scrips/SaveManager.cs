using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class SaveClass
{
    public List<int> score = new List<int>();
    public List<string> maps = new List<string>();
    public List<int> scoreMaps = new List<int>();
    ////método construtor
    //public SaveClass(int score)
    //{
    //    this.score = score;
    //}
}

public static class SaveManager //: MonoBehaviour
    {
   
    //public static SaveManager instance;

    public static void Save(int actualScore, string map, int mapScore)
    {
        //Carrega o que foi carregado antes
        var previousSaveClass = Load();
        //Se não for null, ou seja, se realmente tem algo salvo, ele procura se não existe um mapa carregado e adiciona tanto o mapa quanto o score. 
        //Se não, ele pega o index do mapa anterior e mostra o score da fase. Além disso, se o score do mapa jogado(mapscore) for maior do que o highscore, ele substitui o valor.
        //Após isso, ele salva no path. Porém, se estiver null, Ele cria um novo Save adicionando o score atual, tanto no score quando no mapscore e o mapa.
        if(previousSaveClass != null)
        {
            if(!previousSaveClass.maps.Contains(map))
            {
                previousSaveClass.maps.Add(map);
                previousSaveClass.score.Add(actualScore);
                previousSaveClass.scoreMaps.Add(mapScore);
            } else
            {
                int mapIndex = previousSaveClass.maps.IndexOf(map);
                previousSaveClass.score[mapIndex] = actualScore;
                if (mapScore > previousSaveClass.scoreMaps[mapIndex])
                {
                    previousSaveClass.scoreMaps[mapIndex] = mapScore;
                }     
                
            }
            //var updatedSaveClass = previousSaveClass;           
            var saveJson = JsonUtility.ToJson(previousSaveClass);
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "Save.sav"), saveJson);
        } else
        {
            var _saveclass = new SaveClass();           
            _saveclass.score.Add(actualScore);
            _saveclass.maps.Add(map);
            _saveclass.scoreMaps.Add(mapScore);
            var scoreJson = JsonUtility.ToJson(_saveclass);
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "Save.sav"), scoreJson);
        } 


        Debug.Log("salvou");
        Debug.Log(Application.persistentDataPath);
    }

    public static SaveClass Load()
    {        
        try
        {
            string file = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Save.sav"));
            if (file != null)
            {
                var score = JsonUtility.FromJson(file, typeof(SaveClass)) as SaveClass; //ou
                                                                                        //var score = JsonUtility.FromJson<Score>(Path.Combine(Application.persistentDataPath, "Save.sve"));
                return score;

            }
            else
            {
                return null;
            }
        }
        catch (System.Exception)
        {
            Debug.Log("SaveNãoExiste");
            return null;            
            //throw;
        }
       
        
    }

    /*var _score = new Score(999);
        já ta inicializado >> _score.score = 100;
        Tanto faz os dois
       Save(new Score { score = 100 });



       Save(_score);
       var LoadedScore = Load();
       Debug.Log(LoadedScore.score);*/
}





