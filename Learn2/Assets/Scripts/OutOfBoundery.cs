using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundery : MonoBehaviour
{
    private float maxZ = 35.0f, minZ = -15.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //화면 바깥으로 나간 물체들을 전부 파괴
        if (transform.position.z > maxZ)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < minZ)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }
}
