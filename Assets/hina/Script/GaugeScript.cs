using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeScript : MonoBehaviour
{
    public Image scoreGauge; // �Q�[�W�{�̉摜���C���X�y�N�^�[����Z�b�g
    private int totalScore; // ���_��������ϐ�

    void Update()
    {
        scoreGauge.fillAmount = totalScore / 50.0f;
        // �Q�[�W�𑝌�������R�[�h�͍���͏ȗ�
    }
}
