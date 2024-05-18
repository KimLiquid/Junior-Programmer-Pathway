using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float �ӵ� = 1;
    private float �ӵ�;
    private float rpm;
    private int wheelCount;
    [SerializeField] private float ���� = 30;
    private const float �ڵ鸵 = 30;
    private float �����Է�;
    private float �����Է�;
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
        // ����/����, ��/��ȸ�� �Է�
        �����Է� = Input.GetAxis("Horizontal");
        �����Է� = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //������ ������ �̵�
            //transform.Translate(Vector3.forward * Time.deltaTime * �����Է� * ���������ӵ�);
            playerRb.AddRelativeForce(Vector3.forward * ���� * �����Է�);

            //������ ��/��� ȸ��
            transform.Rotate(Vector3.up, Time.deltaTime * �����Է� * �ڵ鸵);

            �ӵ� = playerRb.velocity.magnitude * 2.237f;
            speedMeter.SetText("Speed : " + (int)�ӵ� + " mph");

            rpm = (�ӵ� % 30) * 40;
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
