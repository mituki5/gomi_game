using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // ゲージのImageコンポーネント

    public float maxValue = 100f; // ゲージの最大値
    public float currentValue = 0; // 現在の値
    public float minValue = 0;
    private bool isIncreasing = true;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isIncreasing)
            {
                GaugeUp();
                if(currentValue >= maxValue)
                {
                    isIncreasing = false;
                }
            }
            else
            {
                GaugeDown();
                if (currentValue <= minValue)
                {
                    isIncreasing = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
                currentValue = minValue;
        }
        // ゲージの画像を更新
        gaugeImage1.fillAmount = currentValue / maxValue;
    }

    private void GaugeUp()
    {
        currentValue += 0.2f;

        if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }
    }

    private void GaugeDown()
    {
        currentValue -= 0.2f;

        if(currentValue < minValue)
        {
            currentValue = minValue;
        }
    }
}
