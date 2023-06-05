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
                //�^�C�g���V�[���ɑJ��
                SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
            }
        }
        
    }

    // �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    void OnTriggerEnter(Collider collider)
    {
        /*
            // �����Փ˂�������I�u�W�F�N�g�̖��O��"Punch"�Ȃ��
            if (collider.gameObject.layer == 3)
            {
                //���ʉ��Đ�
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
                //���̃V�[���ɑJ��
                SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
            }
        */
    }
}
