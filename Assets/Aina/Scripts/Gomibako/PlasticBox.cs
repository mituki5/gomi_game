using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlasticBox : MonoBehaviour
{
    public bool isEnter_p; // (�ٓ�)�S�~�����������ǂ���
    public bool isEnter_c; // (�L���b�v)�S�~�����������ǂ���
    public bool mistake;   // �S�~���Ԉ�����Ƃ���ɓ��������ǂ���

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip clip3; // �������ꏊ�ɃS�~����������
    [SerializeField] private AudioClip clip4; // �Ԉ�����ꏊ�ɃS�~����������
    void Start()
    {
        isEnter_p = false;
        isEnter_c = false;
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
            // ������
            case "moerugomi":     
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                soundManager.Play(clip4);
                break;
            // �ٓ���
            case "plasticgomi":   
                isEnter_p = true;
                Debug.Log("�ٓ�����������");
                Destroy(other.gameObject);
                soundManager.Play(clip3);
                break;
            // �y�b�g�{�g��
            case "plasticbottle": 
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                soundManager.Play(clip4);
                break;
            // �{�g��
            case "bottle":        
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                soundManager.Play(clip4);
                break;
            // �L���b�v
            case "cap":           
                isEnter_c = true;
                Debug.Log("�L���b�v��������");
                Destroy(other.gameObject);
                soundManager.Play(clip3);
                break;
        }
    }
}
