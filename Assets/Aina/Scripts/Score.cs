using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    public int score = 0;
    void Start()
    {
        ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";
    }

    void Update()
    {

    }
}
