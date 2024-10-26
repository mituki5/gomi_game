using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Score : MonoBehaviour
{
    private GameObject Trash;
    private GameObject Trash2;
    private GameObject Trash3;

    [SerializeField] Text ScoreText;
    public int score = 0;
    void Start()
    {
        ScoreText.text = $"スコア：{score.ToString("D3")}";
        Trash = GameObject.Find("trash");
        Trash2 = GameObject.Find("trash2");
        Trash3 = GameObject.Find("trash3");
    }

    void Update()
    {
        if (Trash.GetComponent<Moerugomi>().isEnter == true)
        {
            score += 30;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            Trash.GetComponent<Moerugomi>().isEnter = false;
        }

        if (Trash2.GetComponent<Plasticgomi>().isEnter == true)
        {
            score += 80;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            Trash2.GetComponent<Plasticgomi>().isEnter = false;
        }

        if (Trash3.GetComponent<plasticbottle>().isEnter == true)
        {
            score += 80;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            Trash3.GetComponent<plasticbottle>().isEnter = false;
        }
    }
}
