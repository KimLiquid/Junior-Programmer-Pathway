using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject lookOn;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        lookOn = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDiraction = (lookOn.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDiraction * speed);

        if (transform.position.y < -10)
            Destroy(gameObject);
    }
}
