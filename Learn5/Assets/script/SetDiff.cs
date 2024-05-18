using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDiff : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public float diffMult;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SettingDiff);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SettingDiff()
    {
        Debug.Log(gameObject.name + "ÀÌ ´­·¯Áü");
        gameManager.StartGame(diffMult);
    }
}
