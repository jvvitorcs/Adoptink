using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnHumans : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] humaninho;
    int choice, count, erros;
    [Header("Controllers")]
    public int dificuldade;
    [Range(0, 10)] [SerializeField] private float[] difficultyRange; //Entre as 3 dificuldades, escolher quão rápido vai chegar na dificuldade máxima
    [Range(0.5f, 1)] public float dificuldadeMaxima; // Quanto menor, mais dificil
    [Range(0, 1)]public float aleatoriedade; //Lembrar de deixar menor que a dificuldade máxima (se ficar igual acaba vindo dois em sequencia)

    private void Start()
    {
        StartCoroutine(spawnHumans());
    }
    IEnumerator spawnHumans()
    {

        var gameManager = FindObjectOfType<GameManage>();


        float waitTime = 3;
        float spawnCooldown = 0;
        float spawnCount = 0;

        while (!gameManager.isGameOver())
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0)
            {
                spawnCount++;
                SpawnHuman();

                float nextSpawnCooldown = (waitTime - (((waitTime / 100) * difficultyRange[dificuldade]) * spawnCount));
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