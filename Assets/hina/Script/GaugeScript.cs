using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // �Q�[�W��Image�R���|�[�l���g

    public float maxPower = 100f; // �Q�[�W�̍ő�l
    public float Power = 0; // ���݂̒l
    public float minPower = 0;
    private bool isIncreasing = true; // Max�ɂȂ������̔���
    public float gaugeSpeed = 0; // �Q�[�W�̑���

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
            // �Q�[�W�̉摜���X�V
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
