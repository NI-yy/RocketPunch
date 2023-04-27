using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTitleSceneCube : MonoBehaviour
{
    public AudioClip clip;
    public GameObject SceneDirector;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            //タイトルシーンに遷移
            SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
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
            //次のシーンに遷移
            SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
        }
    }
}
