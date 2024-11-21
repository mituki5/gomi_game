using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;

    [SerializeField]
    private AudioClip clip1; //�����f�[�^

    [SerializeField]
    private AudioClip clip2;

    [SerializeField]
    private AudioClip clip3;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���N���b�N
        {
            soundManager.Play(clip1);
        }
        if (Input.GetMouseButtonDown(1)) //�E�N���b�N
        {
            soundManager.Play(clip2);
        }
        if(Input.GetMouseButtonUp(0))
        {
            soundManager.Play(clip3);
        }
    }
}
