using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextSceneCube : MonoBehaviour
{
    public AudioClip clip;
    public GameObject SceneDirector;

    private void Update()
    {
        /*if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //次のシーンに遷移
            SceneDirector.GetComponent<SceneDirector>().LoadNextScene();
        }*/
    }

    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter(Collider collider)
    {
        // もし衝突した相手オブジェクトの名前が"Punch"ならば
        if (collider.gameObject.layer == 3)
        {
            //効果音再生
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //次のシーンに遷移
            SceneDirector.GetComponent<SceneDirector>().LoadNextScene();
        }
    }

}
