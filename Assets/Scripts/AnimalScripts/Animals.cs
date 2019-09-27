using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    [SerializeField] AnimalScript BlueAnimal, RedAnimal, GreenAnimal, YellowAnimal, OrangeAnimal, PurpleAnimal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            var NewAnimal = Instantiate(GreenAnimal.GetAnimalPrefab(), GreenAnimal.GetSpawnPrefab().transform.position, Quaternion.identity);
        }
        else
        if (Input.GetKeyDown(KeyCode.K))
        {
            var NewAnimal = Instantiate(PurpleAnimal.GetAnimalPrefab(), PurpleAnimal.GetSpawnPrefab().transform.position, Quaternion.identity);
        }
        else
        if (Input.GetKeyDown(KeyCode.L))
        {
            var NewAnimal = Instantiate(OrangeAnimal.GetAnimalPrefab(), OrangeAnimal.GetSpawnPrefab().transform.position, Quaternion.identity);
        }
        else
        if (Input.GetKeyDown(KeyCode.S))
        {
            var NewAnimal = Instantiate(BlueAnimal.GetAnimalPrefab(), BlueAnimal.GetSpawnPrefab().transform.position, Quaternion.identity);
        }
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            var NewAnimal = Instantiate(YellowAnimal.GetAnimalPrefab(), YellowAnimal.GetSpawnPrefab().transform.position, Quaternion.identity);
        }
        else
        if (Input.GetKeyDown(KeyCode.A))
        {
            var NewAnimal = Instantiate(RedAnimal.GetAnimalPrefab(), RedAnimal.GetSpawnPrefab().transform.position, Quaternion.identity);
        }
    }
}