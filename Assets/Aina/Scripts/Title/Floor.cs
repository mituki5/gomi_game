using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject StartBall; // �X�^�[�g�{�[���I�u�W�F�N�g
    [SerializeField] public bool preparation; // �X�^�[�g�{�[���������ł��Ă��邩�ǂ���

    void Start()
    {
        // �q�G�����L�[����T��
        StartBall = GameObject.Find("StartBall");

        preparation = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �X�^�[�g�{�[���ɓ���������
        if (other.gameObject.tag == "startball")
        {
            Destroy(other.gameObject);
            Invoke(nameof(StartBallPreparation), 0.3f); // 0.5f�҂�
        }
    }

    void StartBallPreparation()
    {
        StartBall.SetActive(true);
        preparation = true;
    }
}
