using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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

    [SerializeField] public GameObject BGMSound; // BGM
    [SerializeField] public GameObject BGMSound_twice; // 1.5�{��BGM
    [SerializeField] private AudioClip clip1; // �J�E���g�_�E���̉�
    [SerializeField] public GameObject Sound5; // �Q�[���̎c�莞�Ԃ�m�点�鉹

    bool count1;
    bool count2;
    bool count3;

    void Start()
    {
        // �q�G�����L�[����T��
        BlackImage = GameObject.Find("BlackImage");
        CountDownImage = GameObject.Find("CountDownImage");
        CountDownText = GameObject.Find("CountDownText");

        _time = GameObject.Find("TimeObject");

        BGMSound.SetActive(false);
        BGMSound_twice.SetActive(false);
        Sound5.SetActive(false);

        count1 = false;
        count2 = false;
        count3 = false;
    }

    void Update()
    {
        //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
        time += Time.deltaTime;
        //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
        int remaining1 = timeLimit1 - (int)time;
        //timerText���X�V���Ă���
        timeText1.text = remaining1.ToString("D1");
        switch (remaining1)
        {
            case 3:
                Invoke(nameof(SoundPlay), 0.01f);
                break;
            case 2:
                SoundPlay2();
                break;
            case 1:
                SoundPlay3();
                break;
            case 0:
                BGMSound.SetActive(true);
                BlackImage.SetActive(false);
                CountDownImage.SetActive(false);
                CountDownText.SetActive(false);

                //start = true;

                _time.GetComponent<Title>().start = true;
                break;

        }
        if (_time.GetComponent<Title>().start == true)
        {
            int remaining = timeLimit - (int)time;
            timeText.text = $"�������ԁF{remaining.ToString("D2")}";
            if (remaining == 5)
            {
                BGMSound.SetActive(false);
                Sound5.SetActive(true);
                BGMSound_twice.SetActive(true);
            }
            if (remaining == 0)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
    void SoundPlay()
    {
        if (count1 == false)
        {
            soundManager.Play(clip1);
            count1 = true;
        }
    }
    void SoundPlay2()
    {
        if (count2 == false)
        {
            soundManager.Play(clip1);
            count2 = true;
        }
    }
    void SoundPlay3()
    {
        if (count3 == false)
        {
            soundManager.Play(clip1);
            count3 = true;
        }
    }
}

