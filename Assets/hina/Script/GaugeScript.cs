using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // ゲージのImageコンポーネント

    public float maxValue = 100f; // ゲージの最大値
    public float currentValue = 0; // 現在の値
    public float minValue = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(currentValue == 0)
            {
                GaugeUp();
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
                currentValue = 0;
        }
        // ゲージの画像を更新
        gaugeImage1.fillAmount = currentValue / maxValue;
    }

    private void GaugeUp()
    {
        currentValue += 0.1f;

        if (currentValue >= maxValue)
        {
            currentValue = 100.0f;
        }
    }

    private void GaugeDown()
    {
        if(currentValue == maxValue)
        {
            currentValue -= 0.1f;
        }
    }
}
