using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public GameObject GameDirector;
    private float final_score;

    // Start is called before the first frame update
    void Start()
    {
        final_score = GameDirector.GetComponent<GameDirector>().GetScore();
        Debug.Log("final_score " + final_score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(final_score);
    }
}
