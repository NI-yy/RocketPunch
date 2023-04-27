using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip clip;
    public EnemyGenerator generator;
    public GameObject hitEffect;

    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter(Collider collider)
    {
        // もし衝突した相手オブジェクトの名前が"Cube"ならば
        if (collider.gameObject.CompareTag("PunchCube"))
        {

            generator.EnemyCount--;
            //効果音再生
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //エフェクト再生
            hitEffect.GetComponent<ParticleSystem>().Play();

            Destroy(this.gameObject);
            
        }
    }

}
