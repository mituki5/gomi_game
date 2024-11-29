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
    [SerializeField] private AudioClip clip5; // ゲームの残り時間を知らせる音

    void Start()
    {
        // ヒエラルキーから探す
        BlackImage = GameObject.Find("BlackImage");
        CountDownImage = GameObject.Find("CountDownImage");
        CountDownText = GameObject.Find("CountDownText");

        _time = GameObject.Find("TimeObject");
    }

    void Update()
    {
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        int remaining1 = timeLimit1 - (int)time;
        //timerTextを更新していく
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
            timeText.text = $"制限時間：{remaining.ToString("D2")}";
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