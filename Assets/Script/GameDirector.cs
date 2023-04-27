using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public TMPro.TMP_Text timerText;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text messageText;
    public bool is_final;
    public float time;
    public static float score;
    private bool clearFlag = false;
    private bool playingFlag = true;

    public GameObject EnemyGenerator;

    public GameObject LoadNextSceneCube;
    public GameObject LoadTitleSceneCube;
    public GameObject LoadRankingSceneCube;
    public GameObject MessageCanvas;
    public GameObject FireWorks;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("buildIndex = 0");
            score = 0;
        }
        timerText.SetText("0");
        scoreText.SetText(score.ToString("F1"));
    }

    // Update is called once per frame
    void Update()
    {
        if (playingFlag && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (!clearFlag)
            {
                this.time -= Time.deltaTime;
                this.timerText.SetText(this.time.ToString("F1"));
            }
            else//クリア
            {
                this.timerText.SetText(this.time.ToString("F1"));
                GameClear();
                playingFlag = false;
            }
            
            if (this.time < 0)//タイムアップ
            {
                this.timerText.SetText("0.0");
                EnemyGenerator.GetComponent<EnemyGenerator>().TimeIsUp();
                GameOver();
                playingFlag = false;
            }
        }

    }

    public void AllEnemyIsBreaked()
    {
        clearFlag = true;
    }

    void GameClear()
    {

        if (is_final)
        {
            LoadRankingSceneCube.SetActive(true);
            MessageCanvas.SetActive(true);
            FireWorks.SetActive(true);

            score += time;
            scoreText.SetText(score.ToString("F1"));

            messageText.text = "Congratulations!!\n" + "Your Score is " + score.ToString("F1");
        }
        else
        {
            LoadNextSceneCube.SetActive(true);
            LoadTitleSceneCube.SetActive(true);
            MessageCanvas.SetActive(true);

            score += time;
            scoreText.SetText(score.ToString("F1"));
            messageText.text = "Clear!";
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver!");
        LoadTitleSceneCube.SetActive(true);
        MessageCanvas.SetActive(true);

        messageText.text = "GameOver!\n" + "Your Score is " + score.ToString("F1");
    }

    public float GetScore()
    {
        Debug.Log("return " + score);
        return score;
    }
}
