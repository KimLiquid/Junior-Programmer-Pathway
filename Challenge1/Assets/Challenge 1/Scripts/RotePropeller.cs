using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotePropeller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�����緯 ȸ��
        transform.Rotate(Vector3.forward, Time.deltaTime * 360);
    }
}
