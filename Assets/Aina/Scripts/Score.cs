using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Score : MonoBehaviour
{
    private GameObject Trash;
    private GameObject Trash2;

    [SerializeField] Text ScoreText;
    public int score = 0;
    void Start()
    {
        ScoreText.text = $"スコア：{score.ToString("D3")}";
        Trash = GameObject.Find("trash");
        Trash2 = GameObject.Find("trash2");
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
    }
}
