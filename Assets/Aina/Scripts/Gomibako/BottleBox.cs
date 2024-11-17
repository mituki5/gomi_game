using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottleBox : MonoBehaviour
{
    public bool isEnter_p;
    public bool isEnter_b;
    public bool mistake;
    void Start()
    {
        isEnter_p = false;
        isEnter_b = false;
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
            case "moerugomi":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            case "plasticgomi":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
            case "plasticbottle":
                isEnter_p = true;
                Debug.Log("�y�b�g�{�g��������");
                Destroy(other.gameObject);
                break;
            case "bottle":
                isEnter_b = true;
                Debug.Log("�{�g��������");
                Destroy(other.gameObject);
                break;
            case "cap":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(other.gameObject);
                break;
        }
    }
}
