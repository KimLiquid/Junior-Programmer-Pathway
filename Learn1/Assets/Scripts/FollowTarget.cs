using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject Ÿ��;
    [SerializeField] private Vector3 ������ = new Vector3(0f, 5.5f, -8.5f);
    private Vector3 ���� = new Vector3(16.489f, 0f, 0f);

    // Update is called once per frame
    void LateUpdate()
    {
        //ī�޶� Ÿ���� ����
        transform.position = Ÿ��.transform.position + ������;
        transform.rotation = Quaternion.Euler(����);
    }
}
