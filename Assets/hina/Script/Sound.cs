using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource source; //�X�s�[�J�[�ECD�v���C���[

    [SerializeField]
    private AudioClip clip1; //�����f�[�^1

    [SerializeField]
    private AudioClip clip2; //�����f�[�^2

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���N���b�N
        {
            source.clip = clip1; //�Đ�������clip���w�肵��
            source.Play(); //�Đ�
        }
        if (Input.GetMouseButtonDown(1)) //�E�N���b�N
        {
            source.clip = clip2; //�Đ�������clip���w�肵��
            source.Play(); //�Đ�
        }
    }
}
