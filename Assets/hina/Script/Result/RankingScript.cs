using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class RankingScript : MonoBehaviour
{
    int score1 = Score.score;

    string[] ranking = { "1��", "2��", "3��"};
    int[] rankingValue = new int[3];

    [SerializeField, Header("�\��������e�L�X�g")]
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
    /// �����L���O�Ăяo��
    /// </summary>
    void GetRanking()
    {
        //�����L���O�Ăяo��
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(int _value)
    {
        //�������ݗp
        for (int i = 0; i < ranking.Length; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }

        //����ւ����l��ۑ�
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
