using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRankingScene : MonoBehaviour
{
    public AudioClip clip;
    public GameObject SceneDirector;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            //ランキングシーンに遷移
            SceneDirector.GetComponent<SceneDirector>().LoadRankingScene();
        }
    }

    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter(Collider collider)
    {
        // もし衝突した相手オブジェクトの名前が"Cube"ならば
        if (collider.gameObject.CompareTag("PunchCube"))
        {
            //効果音再生
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //ランキングシーンに遷移
            SceneDirector.GetComponent<SceneDirector>().LoadRankingScene();
        }
    }
}
