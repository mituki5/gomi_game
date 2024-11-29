using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    public float speed = 1.0f;

    private Text Holdtext;         // Holdテキスト
    private GameObject TitleImage; // タイトル画像
    private GameObject Titletext;
    private Image image;
    private float time;

    void Start()
    {
        // ヒエラルキーから探す
        Holdtext = this.gameObject.GetComponent<Text>();
        TitleImage = GameObject.Find("TitleNameImage");
        //Titletext = GameObject.Find("TitleNameText");
    }

    void Update()
    {
        // マウス左クリックして離したら
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            this.gameObject.SetActive(false);
            TitleImage.SetActive(false);
            //Titletext.SetActive(false);
        }
        Holdtext.color = GetAlphaColor(Holdtext.color);
    }

    // Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
