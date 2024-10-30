using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottleBox : MonoBehaviour
{
    [SerializeField] private GameObject trash;
    [SerializeField] private GameObject plastic;
    [SerializeField] private GameObject bottle;
    public bool isEnter;
    public bool mistake;
    void Start()
    {
        isEnter = false;
        mistake = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
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
        switch (collision.gameObject.tag)
        {
            case "moerugomi":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(collision.gameObject);
                break;
            case "plasticgomi":
                mistake = true;
                Debug.Log("�ԈႦ��");
                Destroy(collision.gameObject);
                break;
            case "plasticbottle":
                isEnter = true;
                Debug.Log("�y�b�g�{�g��������");
                Destroy(collision.gameObject);
                break;
        }
    }
}
