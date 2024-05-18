using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapwner : MonoBehaviour
{
    public GameObject prefabsObstacles;
    private Vector3 SpawnPos = new Vector3(30, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacles()
    {
        if(playControllerScript.isGameOver == false)
            Instantiate(prefabsObstacles, SpawnPos, prefabsObstacles.transform.rotation);
    }
}
