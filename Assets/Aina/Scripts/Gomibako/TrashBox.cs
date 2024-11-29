using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    public bool isEnter;  // (紙くず)ゴミが入ったかどうか
    public bool isEnter2; // スタートボールが入ったかどうか
    public bool mistake;  // ゴミが間違ったところに入ったかどうか
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
            // スタートボール
            case "startball":     
                isEnter2 = true;
                Debug.Log("スタートボールが入った");
                Destroy(other.gameObject);
                break;
            // 紙くず
            case "moerugomi":     
                isEnter = true;
                Debug.Log("紙くずが入った");
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
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                break;
        }
    }
}
