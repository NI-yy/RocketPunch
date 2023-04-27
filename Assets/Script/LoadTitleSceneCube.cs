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
            //�^�C�g���V�[���ɑJ��
            SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
        }
    }

    // �Q�[���I�u�W�F�N�g���m���ڐG�����^�C�~���O�Ŏ��s
    void OnTriggerEnter(Collider collider)
    {
        // �����Փ˂�������I�u�W�F�N�g�̖��O��"Cube"�Ȃ��
        if (collider.gameObject.CompareTag("PunchCube"))
        {
            //���ʉ��Đ�
            GameObject.FindObjectOfType<AudioSource>().PlayOneShot(clip);
            //���̃V�[���ɑJ��
            SceneDirector.GetComponent<SceneDirector>().LoadTitleScene();
        }
    }
}
