using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlasticBox : MonoBehaviour
{
    public bool isEnter_p; // (弁当)ゴミが入ったかどうか
    public bool isEnter_c; // (キャップ)ゴミが入ったかどうか
    public bool mistake;   // ゴミが間違ったところに入ったかどうか
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
            // 紙くず
            case "moerugomi":     
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            // 弁当箱
            case "plasticgomi":   
                isEnter_p = true;
                Debug.Log("弁当箱が入った");
                Destroy(other.gameObject);
                break;
            // ペットボトル
            case "plasticbottle": 
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            // ボトル
            case "bottle":        
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            // キャップ
            case "cap":           
                isEnter_c = true;
                Debug.Log("キャップが入った");
                Destroy(other.gameObject);
                break;
        }
    }
}
