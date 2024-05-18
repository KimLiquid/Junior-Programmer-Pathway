using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //음식과 동물이 충돌했을경우 둘다 제거
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
