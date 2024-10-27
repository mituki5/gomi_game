using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Score : MonoBehaviour
{
    private GameObject trash;
    private GameObject plastic;
    private GameObject bottle;

    [SerializeField] Text ScoreText;
    public int score = 0;
    void Start()
    {
        ScoreText.text = $"スコア：{score.ToString("D3")}";
        trash = GameObject.Find("trash");
        plastic = GameObject.Find("plastic");
        bottle = GameObject.Find("bottle");
    }

    void Update()
    {
        if (trash.GetComponent<Moerugomi>().isEnter == true)
        {
            score += 30;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            trash.GetComponent<Moerugomi>().isEnter = false;
        }

        if (plastic.GetComponent<Plasticgomi>().isEnter == true)
        {
            score += 80;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            plastic.GetComponent<Plasticgomi>().isEnter = false;
        }

        if (bottle.GetComponent<Plasticbottle>().isEnter == true)
        {
            score += 80;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            bottle.GetComponent<Plasticbottle>().isEnter = false;
        }

        if (trash.GetComponent<Moerugomi>().mistake == true || plastic.GetComponent<Plasticgomi>().mistake == true || bottle.GetComponent<Plasticbottle>().mistake == true)
        {
            if (score > 0)
            {
                score -= 10;
                ScoreText.text = $"スコア：{score.ToString("D3")}";
                trash.GetComponent<Moerugomi>().mistake = false;
                plastic.GetComponent<Plasticgomi>().mistake = false;
                bottle.GetComponent<Plasticbottle>().mistake = false;
            }
        }
    }
}
