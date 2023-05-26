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
        Debug.Log("�����l" + generator.EnemyCount);
        if (durable)
        {
            
            enemyPrefab.transform.localScale = new Vector3(2, 2, 2);
            lifeText.SetText(life.ToString("F0"));
            count = 0;
            delta = 1 / life;
        }
    }

    // �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("LaserCollider"))
        {
            Debug.Log("Laser�ɐڐG");
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
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //�G�t�F�N�g�Đ�
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if (life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta*count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("�G���[:life���������ݒ肳��Ă��܂���");
                    }
                }
            }

            if (isBlue)
            {
                // �����Փ˂�������I�u�W�F�N�g�̖��O��"Cube"�Ȃ��
                if (collider.gameObject.CompareTag("BluePunch"))
                {
                    life--;
                    if(life == 0)
                    {
                        generator.EnemyCount--;
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //�G�t�F�N�g�Đ�
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if(life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta * count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("�G���[:life���������ݒ肳��Ă��܂���");
                    }
                }
            }

            if (isYellow)
            {
                // �����Փ˂�������I�u�W�F�N�g�̖��O��"Cube"�Ȃ��
                if (collider.gameObject.CompareTag("YellowPunch"))
                {
                    life--;
                    if (life == 0)
                    {
                        generator.EnemyCount--;
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //�G�t�F�N�g�Đ�
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if (life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta * count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("�G���[:life���������ݒ肳��Ă��܂���");
                    }
                }
            }

            if (isRed)
            {
                // �����Փ˂�������I�u�W�F�N�g�̖��O��"Cube"�Ȃ��
                if (collider.gameObject.CompareTag("RedPunch"))
                {
                    life--;
                    if (life == 0)
                    {
                        generator.EnemyCount--;
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                        //�G�t�F�N�g�Đ�
                        hitEffect.GetComponent<ParticleSystem>().Play();

                        lifeCanvas.SetActive(false);
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    else if (life > 0)
                    {
                        enemyPrefab.transform.localScale = new Vector3(2.0f - delta * count, 2.0f - delta * count, 2.0f - delta * count);
                        lifeText.SetText(life.ToString("F0"));
                        //���ʉ��Đ�
                        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    }
                    else
                    {
                        Debug.Log("�G���[:life���������ݒ肳��Ă��܂���");
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
                    //���ʉ��Đ�
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    //�G�t�F�N�g�Đ�
                    hitEffect.GetComponent<ParticleSystem>().Play();

                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    this.gameObject.GetComponent<MeshCollider>().enabled = false;
                }
            }

            if (isBlue)
            {
                // �����Փ˂�������I�u�W�F�N�g�̖��O��"Cube"�Ȃ��
                if (collider.gameObject.CompareTag("BluePunch"))
                {
                    generator.EnemyCount--;
                    //���ʉ��Đ�
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);           
                    //�G�t�F�N�g�Đ�
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
                    //���ʉ��Đ�
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    //�G�t�F�N�g�Đ�
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
                    //���ʉ��Đ�
                    GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                    //�G�t�F�N�g�Đ�
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
        //���ʉ��Đ�
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
        //�G�t�F�N�g�Đ�
        hitEffect.GetComponent<ParticleSystem>().Play();

        Destroy(this.gameObject);
    }

}
