using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeScript : MonoBehaviour
{
    public Image gaugeImage1; // �Q�[�W��Image�R���|�[�l���g
    public Image gaugeImage2;

    public float maxValue = 100f; // �Q�[�W�̍ő�l
    private float currentValue = 0; // ���݂̒l

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
