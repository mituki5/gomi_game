using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    public bool isEnter;
    public bool isEnter2;
    public bool mistake;
    void Start()
    {
        isEnter = false;
        isEnter2 = false;
        mistake = false;
    }

    void Update()
    {
        
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
            case "startball":
                isEnter2 = true;
                Debug.Log("�X�^�[�g��������");
                Destroy(other.gameObject);
                break;
            case "moerugomi":
                isEnter = true;
                Debug.Log("�R����S�~������");
                Destroy(other.gameObject);
                break;
            case "plasticgomi":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            case "plasticbottle":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            case "cap":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            case "bottle":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
        }
    }
}
