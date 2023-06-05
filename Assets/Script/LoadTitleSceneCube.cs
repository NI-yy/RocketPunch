using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTitleSceneCube : MonoBehaviour
{
    public AudioClip clip;
    public GameObject SceneDirector;
    int index;

    private void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("index = " + index);
    }
    

    private void Update()
    {
        if(index == 12)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                //タイトルシーンに遷移
                SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
            }
        }
        
    }

    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter(Collider collider)
    {
        /*
            // もし衝突した相手オブジェクトの名前が"Punch"ならば
            if (collider.gameObject.layer == 3)
            {
                //効果音再生
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                //次のシーンに遷移
                SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
            }
        */
    }
}
