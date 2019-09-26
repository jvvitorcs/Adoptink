using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnHumans : MonoBehaviour
{

    [SerializeField] float timer = 0.5f, wait = 3f;
    [SerializeField] GameObject[] humaninho;
    int choice, count, erros;
    public int dificuldade;
    [Range(0, 10)] [SerializeField] private float[] difficultyRange;
    [Range(0.5f, 1)] public float dificuldadeMaxima; // quanto menor mais dificil
    [Range(0, 1)]public float aleatoriedade; //lembrar de deixar menor ou igual (se ficar igual acaba vindo dois em sequencia) que a dificuldade maxima

    private void Start()
    {
        StartCoroutine(spawnHumans());
    }
    IEnumerator spawnHumans()
    {

        var _GamaManager = FindObjectOfType<GameManage>();


        float _waitTime = 3;
        float spawnCooldown = 0;
        float _spawnCount = 0;

        while (!_GamaManager.isGameOver())
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0)
            {
                _spawnCount++;
                SpawnHuman();

                float nextSpawnCooldown = (_waitTime - (((_waitTime / 100) * difficultyRange[dificuldade]) * _spawnCount));
                spawnCooldown = (nextSpawnCooldown <= dificuldadeMaxima) ? dificuldadeMaxima - Random.Range(0, aleatoriedade) : nextSpawnCooldown - Random.Range(0, aleatoriedade); 
                Debug.Log(spawnCooldown);

            }


            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
    private void SpawnHuman()
    {

        Instantiate(humaninho[Random.Range(0, humaninho.Length)], transform.position, Quaternion.identity);
    }
}