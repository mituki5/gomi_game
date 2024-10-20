using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Score : MonoBehaviour
{
    private GameObject Trash;

    [SerializeField] Text ScoreText;
    public int score = 0;
    void Start()
    {
        ScoreText.text = $"スコア：{score.ToString("D3")}";
    }

    void Update()
    {
        if (Trash.GetComponent<Moerugomi>().isEnter == true)
        {
            score = 30;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
        }
    }
}
