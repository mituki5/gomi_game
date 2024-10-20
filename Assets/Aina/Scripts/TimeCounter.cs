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
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        int remaining = timeLimit - (int)time;
        //timerTextを更新していく
        timeText.text = $"制限時間：{remaining.ToString("D2")}";
        if (remaining == 0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}