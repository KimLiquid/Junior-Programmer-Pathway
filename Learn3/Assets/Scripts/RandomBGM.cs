using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    public AudioClip[] BGM;
    private int Index;
    // Start is called before the first frame update
    void Start()
    {
        Index = Random.Range(0, BGM.Length);
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = BGM[Index];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
