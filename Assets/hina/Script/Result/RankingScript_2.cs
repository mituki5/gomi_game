using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankingScript_2 : MonoBehaviour
{
    public Text[] scoreTexts; 

    void Start() 
    {
        UpdateScoreDisplay();
    }

    // スコアを更新
    public void UpdateScoreDisplay()
    {
        List<int> topScores = ScoreManager.Instance.GetTopScores();
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < topScores.Count) 
            {
                scoreTexts[i].text = topScores[i].ToString();
            }
            else
            {
                scoreTexts[i].text = "";
            }
        }
    }
}
