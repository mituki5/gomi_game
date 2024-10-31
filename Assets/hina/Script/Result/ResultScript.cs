using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ResultScript : MonoBehaviour
{

    [SerializeField] Text ScoreText;

    public static float score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "ScoreÅF" + score.ToString();
    }
}
