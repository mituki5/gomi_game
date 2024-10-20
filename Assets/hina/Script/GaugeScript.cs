using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // ゲージのImageコンポーネント

    public float maxValue = 100f; // ゲージの最大値
    public float currentValue = 0; // 現在の値

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currentValue += 0.1f;

            if (currentValue >= maxValue)
            {
                currentValue = 100.0f;
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
                currentValue = 0;
        }
        // ゲージの画像を更新
        gaugeImage1.fillAmount = currentValue / maxValue;
    }
}
