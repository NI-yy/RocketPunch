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
            //���̃V�[���ɑJ��
            SceneDirector.GetComponent<SceneDirector>().LoadNextScene();
        }*/
    }

    // �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    void OnTriggerEnter(Collider collider)
    {
        // �����Փ˂�������I�u�W�F�N�g�̖��O��"Punch"�Ȃ��
        if (collider.gameObject.layer == 3)
        {
            //���ʉ��Đ�
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //���̃V�[���ɑJ��
            SceneDirector.GetComponent<SceneDirector>().LoadNextScene();
        }
    }

}
