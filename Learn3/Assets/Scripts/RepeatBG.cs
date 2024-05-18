using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    private Vector3 StartPos;
    private float repeatX;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        repeatX = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < StartPos.x - repeatX)
        {
            transform.position = StartPos;
        }
    }
}
