using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter1 : MonoBehaviour
{
    [SerializeField] int timeLimit;
    [SerializeField] Text timeText;
    float time;

    [SerializeField] int timeLimit1;
    [SerializeField] Text timeText1;

    private GameObject BlackImage;
    private GameObject CountDownImage;
    private GameObject CountDownText;

    public bool start;

    void Start()
    {
        BlackImage = GameObject.Find("BlackImage");
        CountDownImage = GameObject.Find("CountDownImage");
        CountDownText = GameObject.Find("CountDownText");
    }

    void Update()
    {
        //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
        time += Time.deltaTime;
        //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
        int remaining1 = timeLimit1 - (int)time;
        //timerText���X�V���Ă���
        timeText1.text = remaining1.ToString("D1");
        if (remaining1 == 0)
        {
            BlackImage.SetActive(false);
            CountDownImage.SetActive(false);
            CountDownText.SetActive(false);

            start = true;
        }
        if (start == true)
        {
            int remaining = timeLimit - (int)time;
            timeText.text = $"�������ԁF{remaining.ToString("D2")}";
            if (remaining == 0)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
}