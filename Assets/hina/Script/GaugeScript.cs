using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeScript : MonoBehaviour
{
    public Image scoreGauge; // ゲージ本体画像をインスペクターからセット
    private int totalScore; // 得点を代入する変数

    void Update()
    {
        scoreGauge.fillAmount = totalScore / 50.0f;
        // ゲージを増減させるコードは今回は省略
    }
}
