using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private GameObject Trash; // ゴミ箱オブジェクト
    //private GameObject time;

    public bool start; // ゲームが動くかどうか

    void Start()
    {
        // ヒエラルキーから探す
        Trash = GameObject.Find("Moeru_Gomibako");
        //time = GameObject.Find("TimeObject");
        //time.GetComponent<TimeCounter>().start = true;

        // 今いるシーンがTitleのとき
        if (SceneManager.GetActiveScene().name == "Title")
        {
            start = true;
        }
        else
        {
            start = false;
        }
    }

    void Update()
    {
        //if (SceneManager.GetActiveScene().name == "GameScene 1")
        //{
        //    start = false;
        //}

        // スタートボールが入ったら
        if (Trash.GetComponent<TrashBox>().isEnter2 == true)
        {
            Invoke(nameof(SceneChange), 0.7f);
            //time.GetComponent<TimeCounter>().start = false;

            start =  false;
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("GameScene 1"); // ゲームシーンに移動
    }
}
