using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class RankingScript : MonoBehaviour
{
    [SerializeField] Text RankingText_1;
    [SerializeField] Text RankingText_2;
    [SerializeField] Text RankingText_3;

    private int Ranking_1;
    private int Ranking_2;
    private int Ranking_3;

    int score1 = Score.score;

    void Start()
    {
        Ranking_1 = 0;
        Ranking_2 = 0;
        Ranking_3 = 0;
    }

    void Update()
    {
        RankingText_1.text = "1F" + Ranking_1.ToString();
        RankingText_2.text = "2F" + Ranking_2.ToString();
        RankingText_3.text = "3F" + Ranking_3.ToString();
    }

    public void RankingChange()
    {
        if(score1 >= Ranking_1)
        {
            Ranking_2 = Ranking_3;
            Ranking_1 = Ranking_2;
            score1 = Ranking_1;
        }
        else if(score1 >= Ranking_2)
        {
            Ranking_2 = Ranking_3;
            score1 = Ranking_2;
        }
        else if(score1 >= Ranking_3)
        {
            score1 = Ranking_3;
        }
    }

    public void UpdateScore(int newScore)
    {
        score1 = newScore;
        RankingChange();
    }
}
