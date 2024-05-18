using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCam : MonoBehaviour
{
    public float roteSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, Time.deltaTime * hInput * roteSpeed);
    }
}
