using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAnimal", menuName = "Animal")]
public class AnimalScript : ScriptableObject
{
    
    [SerializeField] GameObject SparklesVFX, animalPrefab, human, spawnPrefab;
    

    public GameObject GetAnimalPrefab() { return animalPrefab; }
    public GameObject GetSpawnPrefab() { return spawnPrefab; }
    public GameObject GetSparklesVFX() { return SparklesVFX; }
    public GameObject GetHuman() { return human; }    
    
}
