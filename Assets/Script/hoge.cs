using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoge : MonoBehaviour
{
    public GameObject parentCanvas;

    void Start()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(400);

        
    }

    public void Click()
    {
        Debug.Log("ƒNƒŠƒbƒN!");
        GameObject rankingCanvas = GameObject.Find("Canvas");
        //rankingCanvas.gameObject.transform.parent = parentCanvas.transform;
        rankingCanvas.transform.SetParent(parentCanvas.transform, false);
    }
}
