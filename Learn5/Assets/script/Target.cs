using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    public float targetScore;
    public ParticleSystem clickPtc;

    private float minF = 12;
    private float maxF = 16;
    private float torque = 10;
    private float spawnRangeX = 4;
    private float spawnPosY = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RanFor(), ForceMode.Impulse);
        targetRb.AddTorque(RanTor(), RanTor(), RanTor(), ForceMode.Impulse);

        transform.position = RanPos();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(clickPtc, transform.position, clickPtc.transform.rotation);
            gameManager.PrintScore(targetScore);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
            gameManager.IsGameOver();
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 RanFor()
    {
        return Vector3.up * Random.Range(minF, maxF);
    }

    float RanTor()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 RanPos()
    {
        return new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY);
    }

}
