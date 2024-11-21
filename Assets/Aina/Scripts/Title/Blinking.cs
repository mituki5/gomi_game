using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{

    public float speed = 1.0f;

    //private
    private Text Holdtext;
    private GameObject TitleImage;
    private GameObject Titletext;
    private Image image;
    private GameObject StartBall;
    private float time;

    void Start()
    {
        Holdtext = this.gameObject.GetComponent<Text>();
        TitleImage = GameObject.Find("TitleNameImage");
        //Titletext = GameObject.Find("TitleNameText");
        StartBall = GameObject.Find("StartBall");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            this.gameObject.SetActive(false);
            TitleImage.SetActive(false);
            //Titletext.SetActive(false);
            StartBall.SetActive(false);
        }
        Holdtext.color = GetAlphaColor(Holdtext.color);
    }
    //AlphaílÇçXêVÇµÇƒColorÇï‘Ç∑
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
