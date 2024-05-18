using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBG : MonoBehaviour
{
    public Sprite[] bgList;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spRander = GetComponent<SpriteRenderer>();
        int Index = bgList.Length;
        spRander.sprite = bgList[Random.Range(0, Index)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
