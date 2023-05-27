using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryController : MonoBehaviour
{
    public AudioClip clip;
    public GameObject SceneDirector;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            SceneDirector.GetComponent<SceneDirector>().Retry();
        }
    }

    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter(Collider collider)
    {
        // もし衝突した相手オブジェクトの名前が"Punch"ならば
        if (collider.gameObject.layer == 3)
        {
            //効果音再生
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //リトライ
            Debug.Log("リトライ前");
            SceneDirector.GetComponent<SceneDirector>().Retry();
            Debug.Log("リトライ後");
        }
    }
}
