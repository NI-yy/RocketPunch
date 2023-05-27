using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    //test
    private int index;
    public GameObject GameDirector;


    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        index++;
        SceneManager.LoadScene(index);
        Debug.Log("Next" + index);
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadRankingScene()
    {
        SceneManager.LoadScene("RankingScene");
    }

    public void Retry()
    {
        Debug.Log("ResetScore‘O");
        GameDirector.GetComponent<GameDirector>().ResetScore();
        Debug.Log("ResetScoreŒã");
        int index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("BuildIndexŽæ“¾Š®—¹");
        SceneManager.LoadScene(index);
        Debug.Log("SceneManager.LoadScene(index)");
    }
}
