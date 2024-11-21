using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private List<int> highScores = new List<int>();

    // スコアを追加し、リストをソートしてトップ3を維持
    public void AddScore(int score)
    {
        highScores.Add(score);
        highScores.Sort((a, b) => b.CompareTo(a));
        if (highScores.Count > 3) 
        {
            highScores.RemoveAt(3); // トップ3以外のスコアは削除
        }
    }

    // トップ3のスコアを取得
    public List<int> GetTopScores()
    {
        return highScores.GetRange(0, Mathf.Min(3, highScores.Count));
    }
}
