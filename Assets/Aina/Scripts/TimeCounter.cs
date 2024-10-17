using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] int timeLimit;
    [SerializeField] Text timerText;
    float time;

    void Update()
    {
        //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
        time += Time.deltaTime;
        //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
        int remaining = timeLimit - (int)time;
        //timerText���X�V���Ă���
        timerText.text = $"�������ԁF{remaining.ToString("D2")}";
    }
}