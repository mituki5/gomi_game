using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlasticBox : MonoBehaviour
{
    public bool isEnter_p;
    public bool isEnter_c;
    public bool mistake;
    void Start()
    {
        isEnter_p = false;
        isEnter_c = false;
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
            case "moerugomi":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            case "plasticgomi":
                isEnter_p = true;
                Debug.Log("プラゴミ入った");
                Destroy(other.gameObject);
                break;
            case "plasticbottle":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            case "bottle":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            case "cap":
                isEnter_c = true;
                Debug.Log("キャップ入った");
                Destroy(other.gameObject);
                break;
        }
    }
}
