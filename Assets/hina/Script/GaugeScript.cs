using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // �Q�[�W��Image�R���|�[�l���g

    public float maxValue = 100f; // �Q�[�W�̍ő�l
    public float currentValue = 0; // ���݂̒l
    public float minValue = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
                GaugeUp();
        }
        if (Input.GetMouseButtonUp(0))
        {
                currentValue = minValue;
        }
        // �Q�[�W�̉摜���X�V
        gaugeImage1.fillAmount = currentValue / maxValue;
    }

    private void GaugeUp()
    {
        currentValue += 0.2f;

        if (currentValue >= maxValue)
        {
            //currentValue = 100.0f;
            GaugeDown();
        }
    }

    private void GaugeDown()
    {
//        if(currentValue == maxValue)
//        {
            currentValue -= 0.1f;
//        }
    }
}
