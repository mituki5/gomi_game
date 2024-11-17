using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // ゲージのImageコンポーネント

    public float maxPower = 100f; // ゲージの最大値
    public float Power = 0; // 現在の値
    public float minPower = 0;
    private bool isIncreasing = true; // Maxになったかの判定
    public float gaugeSpeed = 0; // ゲージの速さ

    private GameObject _time;

    void Start()
    {
        _time = GameObject.Find("TimeObject");
    }

    void Update()
    {
        if (_time.GetComponent<Title>().start == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (isIncreasing)
                {
                    GaugeUp();
                    if (Power >= maxPower)
                    {
                        isIncreasing = false;
                    }
                }
                else
                {
                    GaugeDown();
                    if (Power <= minPower)
                    {
                        isIncreasing = true;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Power = minPower;
            }
            // ゲージの画像を更新
            gaugeImage1.fillAmount = Power / maxPower;
        }
    }

    private void GaugeUp()
    {
        Power += gaugeSpeed;

        if (Power > maxPower)
        {
            Power = maxPower;
        }
    }

    private void GaugeDown()
    {
        Power -= gaugeSpeed;

        if(Power < minPower)
        {
            Power = minPower;
        }
    }
}
