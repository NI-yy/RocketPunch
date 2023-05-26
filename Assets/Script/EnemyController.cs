using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip clip;
    public EnemyGenerator generator;
    public GameObject hitEffect;
    public GameObject enemyPrefab;
    public GameObject lifeCanvas;
    public TMPro.TMP_Text lifeText;
    public bool isNormal;
    public bool isBlue;
    public bool isYellow;
    public bool isRed;
    public bool durable;
    public float life;

    int count;
    float delta;

    private void Start()
    {
        Debug.Log("初期値" + generator.EnemyCount);
        if (durable)
        {
            
            enemyPrefab.transform.localScale = new Vector3(2, 2, 2);
            lifeText.SetText(life.ToString("F0"));
            count = 0;
            delta = 1 / life;
        }
    }

    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("LaserCollider"))
        {
            Debug.Log("Laserに接触");
            generator.GameDirector.GetComponent<GameDirector>().GameOver();
        }

        if (durable)
        {
            if (isNormal)
            {
                if (collider.gameObject.CompareTag("NormalPunch"))
                {
                    count++;
                    life--;
                    if(life == 0)
                    {
                        generator.EnemyCount--;
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //エフェクト再生
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if (life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta*count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("エラー:lifeが正しく設定されていません");
                    }
                }
            }

            if (isBlue)
            {
                // もし衝突した相手オブジェクトの名前が"Cube"ならば
                if (collider.gameObject.CompareTag("BluePunch"))
                {
                    life--;
                    if(life == 0)
                    {
                        generator.EnemyCount--;
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //エフェクト再生
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if(life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta * count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("エラー:lifeが正しく設定されていません");
                    }
                }
            }

            if (isYellow)
            {
                // もし衝突した相手オブジェクトの名前が"Cube"ならば
                if (collider.gameObject.CompareTag("YellowPunch"))
                {
                    life--;
                    if (life == 0)
                    {
                        generator.EnemyCount--;
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //エフェクト再生
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if (life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta * count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("エラー:lifeが正しく設定されていません");
                    }
                }
            }

            if (isRed)
            {
                // もし衝突した相手オブジェクトの名前が"Cube"ならば
                if (collider.gameObject.CompareTag("RedPunch"))
                {
                    life--;
                    if (life == 0)
                    {
                        generator.EnemyCount--;
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //エフェクト再生
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if (life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta * count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //効果音再生
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("エラー:lifeが正しく設定されていません");
                    }
                }
            }

        }
        else
        {
            if (isNormal)
            {
                if (collider.gameObject.CompareTag("NormalPunch"))
                {
                    generator.EnemyCount--;
                    //効果音再生
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    //エフェクト再生
                    hitEffect.GetComponent<ParticleSystem>().Play();

                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    this.gameObject.GetComponent<MeshCollider>().enabled = false;
                }
            }

            if (isBlue)
            {
                // もし衝突した相手オブジェクトの名前が"Cube"ならば
                if (collider.gameObject.CompareTag("BluePunch"))
                {
                    generator.EnemyCount--;
                    //効果音再生
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);           
                    //エフェクト再生
                    hitEffect.GetComponent<ParticleSystem>().Play();                    

                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    this.gameObject.GetComponent<MeshCollider>().enabled = false;
                }
            }

            if (isYellow)
            {
                if (collider.gameObject.CompareTag("YellowPunch"))
                {
                    generator.EnemyCount--;
                    //効果音再生
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    //エフェクト再生
                    hitEffect.GetComponent<ParticleSystem>().Play();

                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    this.gameObject.GetComponent<MeshCollider>().enabled = false;
                }
            }

            if (isRed)
            {
                if (collider.gameObject.CompareTag("RedPunch"))
                {
                    generator.EnemyCount--;
                    //効果音再生
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    //エフェクト再生
                    hitEffect.GetComponent<ParticleSystem>().Play();

                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    this.gameObject.GetComponent<MeshCollider>().enabled = false;
                }
            }
        }

        
    }

    public void Test()
    {
        Debug.Log(generator.EnemyCount--);
        generator.EnemyCount--;
        //効果音再生
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
        //エフェクト再生
        hitEffect.GetComponent<ParticleSystem>().Play();

        Destroy(this.gameObject);
    }

}
