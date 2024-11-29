using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class RankingScript : MonoBehaviour
{
    int score1 = Score.score;

    string[] ranking = { "1位", "2位", "3位"};
    int[] rankingValue = new int[3];

    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[3];

    // Use this for initialization
    void Start()
    {
        GetRanking();

        SetRanking(score1);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }

        ScoreDataDeleit();
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }

    void ScoreDataDeleit()
    {
        PlayerPrefs.DeleteKey("score");
    }
    public void UpdateScore(int newScore)
    {
        score1 = newScore;
    }
}
