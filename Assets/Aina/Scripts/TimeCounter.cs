using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] int timeLimit;
    [SerializeField] Text timeText;
    float time;

    void Update()
    {
        //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
        time += Time.deltaTime;
        //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
        int remaining = timeLimit - (int)time;
        //timerText���X�V���Ă���
        timeText.text = $"�������ԁF{remaining.ToString("D2")}";
        if (remaining == 0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}