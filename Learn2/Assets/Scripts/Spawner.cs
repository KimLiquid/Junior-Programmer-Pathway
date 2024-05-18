using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] animal;
    private float SpawnRange = 15f;
    private float PosZ = 34f;
    private float SpawnStartTime = 2f;
    private float SpawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", SpawnStartTime, SpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnAnimal()
    {
        Vector3 SpawnPos = new Vector3(Random.Range(-SpawnRange, SpawnRange), 0f, PosZ);
        int animalIndex = Random.Range(0, animal.Length);
        Instantiate(animal[animalIndex], SpawnPos, animal[animalIndex].transform.rotation);
    }

}
