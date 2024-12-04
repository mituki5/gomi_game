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
    [SerializeField] public GameObject BGMSound_twice; // 1.5倍のBGM
    [SerializeField] private AudioClip clip1; // カウントダウンの音
    [SerializeField] public GameObject clip5; // ゲームの残り時間を知らせる音

    bool count1;
    void Start()
    {
        // ヒエラルキーから探す
        BlackImage = GameObject.Find("BlackImage");
        CountDownImage = GameObject.Find("CountDownImage");
        CountDownText = GameObject.Find("CountDownText");

        _time = GameObject.Find("TimeObject");

        BGMSound.SetActive(false);
        BGMSound_twice.SetActive(false);
        clip5.SetActive(false);

        count1 = false;
    }

    void Update()
    {
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        int remaining1 = timeLimit1 - (int)time;
        //timerTextを更新していく
        timeText1.text = remaining1.ToString("D1");
        switch (remaining1)
        {
            case 3:
                SoundPlay();
                break;
            case 2:
                SoundPlay();
                break;
            case 1:
                SoundPlay();
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
            timeText.text = $"制限時間：{remaining.ToString("D2")}";
            if (remaining == 5)
            {
                BGMSound.SetActive(false);
                clip5.SetActive(true);
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
}

