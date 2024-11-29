using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottleBox : MonoBehaviour
{
    public bool isEnter_p; // (ペットボトル)ゴミが入ったかどうか
    public bool isEnter_b; // (ボトル)ゴミが入ったかどうか
    public bool mistake;   // ゴミが間違ったところに入ったかどうか

    void Start()
    {
        isEnter_p = false;
        isEnter_b = false;
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
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
            // ペットボトル
            case "plasticbottle": 
                isEnter_p = true;
                Debug.Log("ペットボトルが入った");
                Destroy(other.gameObject);
                break;
            // ボトル
            case "bottle":        
                isEnter_b = true;
                Debug.Log("ボトルが入った");
                Destroy(other.gameObject);
                break;
            // キャップ
            case "cap":           
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
        }
    }
}
