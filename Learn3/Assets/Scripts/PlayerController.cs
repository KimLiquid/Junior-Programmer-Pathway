using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rgBody;
    private Animator playerAnim;
    private AudioSource Sound;
    public ParticleSystem exParticle;
    public ParticleSystem runParticle;
    public AudioClip jumpSound;
    public AudioClip exSound;
    public float JumpForce;
    public float GravityMod;
    public bool isOnGround = true;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Sound = GetComponent<AudioSource>();
        Physics.gravity *= GravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            rgBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Sound.PlayOneShot(jumpSound, 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            runParticle.Stop();
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            runParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            isGameOver = true;
            Debug.Log("GAME OVER!");
            Sound.PlayOneShot(exSound, 1.0f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            runParticle.Stop();
            exParticle.Play();
        }

    }
}
