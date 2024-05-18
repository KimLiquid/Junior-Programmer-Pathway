using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float 속도 = 1;
    private float 속도;
    private float rpm;
    private int wheelCount;
    [SerializeField] private float 마력 = 30;
    private const float 핸들링 = 30;
    private float 수평입력;
    private float 수직입력;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMess;
    [SerializeField] TextMeshProUGUI speedMeter;
    [SerializeField] TextMeshProUGUI rpmMeter;
    [SerializeField] List<WheelCollider> wheels;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMess.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 전진/후진, 좌/우회전 입력
        수평입력 = Input.GetAxis("Horizontal");
        수직입력 = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //차량을 앞으로 이동
            //transform.Translate(Vector3.forward * Time.deltaTime * 수직입력 * 전진후진속도);
            playerRb.AddRelativeForce(Vector3.forward * 마력 * 수직입력);

            //차량을 좌/우로 회전
            transform.Rotate(Vector3.up, Time.deltaTime * 수평입력 * 핸들링);

            속도 = playerRb.velocity.magnitude * 2.237f;
            speedMeter.SetText("Speed : " + (int)속도 + " mph");

            rpm = (속도 % 30) * 40;
            rpmMeter.SetText("RPM : " + (int)rpm);
        }
    }

    bool IsOnGround()
    {
        wheelCount = 0;
        foreach(WheelCollider wheel in wheels)
        {
            if(wheel.isGrounded)
            {
                wheelCount++;
            }
        }

        if (wheelCount == 4)
            return true;
        else return false;
    }
}
