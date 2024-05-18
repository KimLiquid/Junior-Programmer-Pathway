using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject 타겟;
    [SerializeField] private Vector3 오프셋 = new Vector3(0f, 5.5f, -8.5f);
    private Vector3 각도 = new Vector3(16.489f, 0f, 0f);

    // Update is called once per frame
    void LateUpdate()
    {
        //카메라가 타겟을 따라감
        transform.position = 타겟.transform.position + 오프셋;
        transform.rotation = Quaternion.Euler(각도);
    }
}
