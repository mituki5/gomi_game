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

    [SerializeField] int timeLimit1;
    [SerializeField] Text timeText1;

    private GameObject BlackImage;
    private GameObject CountDownImage;
    private GameObject CountDownText;

    //public bool start;

    private GameObject _time;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip clip5; // �Q�[���̎c�莞�Ԃ�m�点�鉹

    void Start()
    {
        // �q�G�����L�[����T��
        BlackImage = GameObject.Find("BlackImage");
        CountDownImage = GameObject.Find("CountDownImage");
        CountDownText = GameObject.Find("CountDownText");

        _time = GameObject.Find("TimeObject");
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

            //start = true;

            _time.GetComponent<Title>().start = true;
        }
        if (_time.GetComponent<Title>().start == true)
        {
            int remaining = timeLimit - (int)time;
            timeText.text = $"�������ԁF{remaining.ToString("D2")}";
            if (remaining == 5)
            {
                soundManager.Play(clip5);
            }
            if (remaining == 0)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
}