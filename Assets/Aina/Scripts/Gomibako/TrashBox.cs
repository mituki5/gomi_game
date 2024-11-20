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
            Debug.Log("燃えるゴミ入った");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticgomi")
        {
            Debug.Log("プラゴミ入った");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticbottle")
        {
            Debug.Log("ペットボトル入った");
            isEnter = true;
            Destroy(collision.gameObject);
        }*/
        switch (other.gameObject.tag)
        {
            case "startball":
                isEnter2 = true;
                Debug.Log("スタートが入った");
                Destroy(other.gameObject);
                break;
            case "moerugomi":
                isEnter = true;
                Debug.Log("燃えるゴミ入った");
                Destroy(other.gameObject);
                break;
            case "plasticgomi":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            case "plasticbottle":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            case "cap":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            case "bottle":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
        }
    }
}
