using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Prefabs; // 生成するプレファブの配列
    private float time; // タイマー用の変数
    private int number; // ランダムに選ばれたプレファブのインデックス

    void Start()
    {
        time = 2.0f; // Startが呼ばれた時、タイマーを1秒に設定
    }

    void Update()
    {
        time -= Time.deltaTime; // タイマーを減少させる
        if (time <= 0.0f) // タイマーが0以下になったら
        {
            time = 2.0f; // タイマーをリセット
            number = Random.Range(0, Prefabs.Length); // プレファブ配列からランダムにインデックスを選ぶ
            Instantiate(Prefabs[number], new Vector3(12, 4, 0), Quaternion.identity); // 選ばれたプレファブを生成
        }
    }
}
