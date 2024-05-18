using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    public GameObject titleScreen;
    public Button reStartButton;

    private float score = 0;
    private float spawnRate = 1;

    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(float diff)
    {
        spawnRate /= diff;
        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSecondsRealtime(spawnRate);
            int Index = Random.Range(0, target.Count);
            Instantiate(target[Index]);
            PrintScore(0.5f);
        }
    }

    public void IsGameOver()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        finalScoreText.text = "최종 점수 : " + (int)score + "점";
        finalScoreText.gameObject.SetActive(true);
        reStartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void PrintScore(float addScore)
    {
        score += addScore;
        scoreText.text = "점수 : " + (int)score;
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
