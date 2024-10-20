using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // �Q�[�W��Image�R���|�[�l���g

    public float maxValue = 100f; // �Q�[�W�̍ő�l
    public float currentValue = 0; // ���݂̒l

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
        // �Q�[�W�̉摜���X�V
        gaugeImage1.fillAmount = currentValue / maxValue;
    }
}
