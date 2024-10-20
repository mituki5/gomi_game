using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript1 : MonoBehaviour
{
    [SerializeField] Text ScoreText;

    float Score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject Trash_1;
    [SerializeField] GameObject Trash_2;

    // Update is called once per frame
    void Start()
    {
        scoreText.text = "Score:" + Score;
    }

    void ScoreCount()
    {
        Score scorescript = GetComponent<Score>();
        scorescript.score = 30;
        ScoreText.text = $"スコア：{scorescript.score.ToString("D3")}";
    }
}
