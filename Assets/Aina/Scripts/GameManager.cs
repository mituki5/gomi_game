using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Prefabs; // ��������v���t�@�u�̔z��
    private float time; // �^�C�}�[�p�̕ϐ�
    private int number; // �����_���ɑI�΂ꂽ�v���t�@�u�̃C���f�b�N�X

    void Start()
    {
        time = 2.0f; // Start���Ă΂ꂽ���A�^�C�}�[��1�b�ɐݒ�
    }

    void Update()
    {
        time -= Time.deltaTime; // �^�C�}�[������������
        if (time <= 0.0f) // �^�C�}�[��0�ȉ��ɂȂ�����
        {
            time = 2.0f; // �^�C�}�[�����Z�b�g
            number = Random.Range(0, Prefabs.Length); // �v���t�@�u�z�񂩂烉���_���ɃC���f�b�N�X��I��
            Instantiate(Prefabs[number], new Vector3(12, 4, 0), Quaternion.identity); // �I�΂ꂽ�v���t�@�u�𐶐�
        }
    }
}
