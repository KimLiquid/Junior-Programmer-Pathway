using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController123 : MonoBehaviour
{
    private Animator anim;
    public float animSpeed = 1.5f;
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    private AnimatorStateInfo currentBaseState;
    
    public float hInput;
    public float xRange = 10.0f;
    public float hspeed = 10.0f;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평입력
        hInput = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", hInput);
        anim.speed = animSpeed;
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        //벽 체크
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //탄환 발사
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }

        //좌우이동
        transform.Translate(Vector3.right * Time.deltaTime * hInput * hspeed);
    }
}
