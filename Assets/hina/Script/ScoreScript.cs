using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    float Score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject Trash_1;
    [SerializeField] GameObject Trash_2;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + Score;
    }
}
