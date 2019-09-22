using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnHumans : MonoBehaviour
{

    [SerializeField] float timer = 0.5f, wait = 3f;
    [SerializeField] GameObject[] humaninho;
    int choice, count, erros;
    //Animals AA;
    City city;

    GameManage GM;

    void Start()
    {
        //AA = FindObjectOfType<Animals>();
        GM = FindObjectOfType<GameManage>();
        city = FindObjectOfType<City>();
    }

    void Update()
    {
        
        timer -= Time.deltaTime;        
        Escolha();

        if (wait <= 1)
        {
            wait = 1;
        }
    }

   

    private void Escolha()
    {
        if (timer <= 0)
        {
            //AA.permitido = true;
            choice = Random.Range(0, 11);
            if (choice <= 1)
            {
                Instantiate(humaninho[0], transform.position, Quaternion.identity);
                timer = wait;
            }
            else if (choice <= 3)
            {
                Instantiate(humaninho[1], transform.position, Quaternion.identity);
                timer = wait;
            }
            else if (choice <= 5)
            {
                Instantiate(humaninho[2], transform.position, Quaternion.identity);
                timer = wait;
            }
            else if (choice <= 7)
            {
                Instantiate(humaninho[3], transform.position, Quaternion.identity);
                timer = wait;
            }
            else if (choice <= 9)
            {
                Instantiate(humaninho[4], transform.position, Quaternion.identity);
                timer = wait;
            }
            else if (choice <= 11)
            {
                Instantiate(humaninho[5], transform.position, Quaternion.identity);
                timer = wait;
            }

            count += 1;
          

            if (count == 5)
            {
               //timer = 5f;
                count = 0;
                wait -= .3f;
                //Invoke("PerderVida", 2);

            }

        }
    }

    /*
    private void PerderVida()
    {
        AA.permitido = false;
        if (GM.points != 5)
        {
            erros ++;
            GM.life -= 1;
            GM.points = 0;
            Erros();
        }
    }

    void Erros()
    {
        if(erros == 3)
        {           
            city.Diminuir();
            erros = 0;
        }
    }*/
}

