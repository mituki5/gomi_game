using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBallScript : MonoBehaviour
{
    public GameObject StartBall; // �X�^�[�g�{�[���I�u�W�F�N�g
    void Update()
    {
        // �}�E�X���N���b�N���ė�������
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartBall.SetActive(false);
        }
    }
}
