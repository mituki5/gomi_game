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
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Holdtext = this.gameObject.GetComponent<Text>();
        TitleImage = GameObject.Find("TitleNameImage");
        Titletext = GameObject.Find("TitleNameText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.gameObject.SetActive(false);
            TitleImage.SetActive(false);
            Titletext.SetActive(false);
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
