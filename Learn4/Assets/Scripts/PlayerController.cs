using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject targetCam;
    public GameObject powerUpInd;
    public float speed;
    public bool hasPowerUp;
    public float powerAttackDmg;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        targetCam = GameObject.Find("Camera Target");
    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        playerRb.AddForce(targetCam.transform.forward * vInput * speed);
        powerUpInd.transform.position = transform.position + new Vector3(0, 0.75f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpInd.SetActive(true);
            StartCoroutine(PowerUpCountdown());
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSecondsRealtime(7);
        hasPowerUp = false;
        powerUpInd.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyDmg = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 damage = collision.gameObject.transform.position - transform.position;

            Debug.Log("치명적인 일격! ( 피격당한 대상 : " + collision.gameObject.name + " )");
            enemyDmg.AddForce(damage * powerAttackDmg, ForceMode.Impulse);
        }
    }
}
