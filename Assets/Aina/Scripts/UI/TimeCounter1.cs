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

            start = true;
        }
        if (start == true)
        {
            int remaining = timeLimit - (int)time;
            timeText.text = $"制限時間：{remaining.ToString("D2")}";
            if (remaining == 0)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
}