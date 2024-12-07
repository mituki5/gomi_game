using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    public bool isEnter;  // (紙くず)ゴミが入ったかどうか
    public bool isEnter2; // スタートボールが入ったかどうか
    public bool mistake;  // ゴミが間違ったところに入ったかどうか

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip clip3; // 正しい場所にゴミが入った音
    [SerializeField] private AudioClip clip4; // 間違った場所にゴミが入った音
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
                soundManager.Play(clip3);
                break;
            // 紙くず
            case "moerugomi":     
                isEnter = true;
                Debug.Log("紙くずが入った");
                Destroy(other.gameObject);
                soundManager.Play(clip3);
                break;
            // 弁当箱
            case "plasticgomi":   
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                soundManager.Play(clip4);
                break;
            // ペットボトル
            case "plasticbottle": 
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                soundManager.Play(clip4);
                break;
            // ボトル
            case "bottle":        
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                soundManager.Play(clip4);
                break;
            // キャップ
            case "cap":           
                mistake = true;
                Debug.Log("間違えた");
                Destroy(other.gameObject);
                soundManager.Play(clip4);
                break;
        }
    }
}
