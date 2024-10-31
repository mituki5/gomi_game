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

    private float Ranking_1;
    private float Ranking_2;
    private float Ranking_3;

    public static float score;

    // Start is called before the first frame update
    void Start()
    {
        Ranking_1 = 0;
        Ranking_2 = 0;
        Ranking_3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RankingText_1.text = "1F" + Ranking_1.ToString();
        RankingText_2.text = "2F" + Ranking_2.ToString();
        RankingText_3.text = "3F" + Ranking_3.ToString();
    }

    public void RankingChange()
    {
        if(score >= Ranking_1)
        {
            Ranking_2 = Ranking_3;
            Ranking_1 = Ranking_2;
            score = Ranking_1;
        }
        else if(score >= Ranking_2)
        {
            Ranking_2 = Ranking_3;
            score = Ranking_2;
        }
        else if(score >= Ranking_3)
        {
            score = Ranking_3;
        }
    }

    public void UpdateScore(float newScore)
    {
        score = newScore;
        RankingChange();
    }
}
