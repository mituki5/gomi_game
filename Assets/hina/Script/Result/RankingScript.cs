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

    public float Ranking_1;
    public float Ranking_2;
    public float Ranking_3;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RankingChange()
    {
        if(score >= Ranking_1)
        {
            Ranking_1 = score;
        }
        else if(score >= Ranking_2)
        {

        }
    }
}
