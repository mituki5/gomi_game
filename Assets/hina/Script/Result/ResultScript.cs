using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{

    [SerializeField] Text ScoreText;

    int score1 = Score.score;

    void Start()
    {

    }

    void Update()
    {
        ScoreText.text = "ScoreÅF" + score1.ToString();
    }
}
