using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    public bool isEnter;  // (������)�S�~�����������ǂ���
    public bool isEnter2; // �X�^�[�g�{�[�������������ǂ���
    public bool mistake;  // �S�~���Ԉ�����Ƃ���ɓ��������ǂ���
    void Start()
    {
        isEnter = false;
        isEnter2 = false;
        mistake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (collision.gameObject.tag == "moerugomi")
        {
            Debug.Log("�R����S�~������");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticgomi")
        {
            Debug.Log("�v���S�~������");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticbottle")
        {
            Debug.Log("�y�b�g�{�g��������");
            isEnter = true;
            Destroy(collision.gameObject);
        }*/

        switch (other.gameObject.tag)
        {
            // �X�^�[�g�{�[��
            case "startball":     
                isEnter2 = true;
                Debug.Log("�X�^�[�g�{�[����������");
                Destroy(other.gameObject);
                break;
            // ������
            case "moerugomi":     
                isEnter = true;
                Debug.Log("��������������");
                Destroy(other.gameObject);
                break;
            // �ٓ���
            case "plasticgomi":   
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            // �y�b�g�{�g��
            case "plasticbottle": 
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            // �{�g��
            case "bottle":        
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            // �L���b�v
            case "cap":           
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
        }
    }
}
