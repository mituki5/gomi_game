using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // ゲージのImageコンポーネント
    public Image gaugeImage2;

    public float maxValue = 100f; // ゲージの最大値
    private float currentValue = 0; // 現在の値

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentValue += 1;

            if(currentValue >= maxValue)
            {
                currentValue = 100;
            }
            if(Input.GetMouseButtonDown(0))
            {
                currentValue = 0;
            }
        }

    }
}
