using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private List<int> highScores = new List<int>();

    // �X�R�A��ǉ����A���X�g���\�[�g���ăg�b�v3���ێ�
    public void AddScore(int score)
    {
        highScores.Add(score);
        highScores.Sort((a, b) => b.CompareTo(a));
        if (highScores.Count > 3) 
        {
            highScores.RemoveAt(3); // �g�b�v3�ȊO�̃X�R�A�͍폜
        }
    }

    // �g�b�v3�̃X�R�A���擾
    public List<int> GetTopScores()
    {
        return highScores.GetRange(0, Mathf.Min(3, highScores.Count));
    }
}
