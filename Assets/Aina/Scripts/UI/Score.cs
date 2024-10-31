using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreText;

    private GameObject trash;
    private GameObject plastic;
    private GameObject bottle;
    public int score = 0;
    void Start()
    {
        ScoreText.text = $"スコア：{score.ToString("D3")}";

        trash = GameObject.Find("Moeru_Gomibako");
        plastic = GameObject.Find("Plastic_Gomibako");
        bottle = GameObject.Find("Bottle_Gomibako");
    }

    void Update()
    {
        if (trash.GetComponent<TrashBox>().isEnter == true)
        {
            score += 30;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            trash.GetComponent<TrashBox>().isEnter = false;
        }
        if (plastic.GetComponent<PlasticBox>().isEnter == true)
        {
            score += 80;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            plastic.GetComponent<PlasticBox>().isEnter = false;
        }
        if (bottle.GetComponent<BottleBox>().isEnter == true)
        {
            score += 100;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            bottle.GetComponent<BottleBox>().isEnter = false;
        }

        if (trash.GetComponent<TrashBox>().mistake == true || plastic.GetComponent<PlasticBox>().mistake == true || bottle.GetComponent<BottleBox>().mistake == true)
        {
            if (score > 0)
            {
                score -= 10;
                ScoreText.text = $"スコア：{score.ToString("D3")}";
                trash.GetComponent<TrashBox>().mistake = false;
                plastic.GetComponent<PlasticBox>().mistake = false;
                bottle.GetComponent<BottleBox>().mistake = false;
            }
        }
    }
}
