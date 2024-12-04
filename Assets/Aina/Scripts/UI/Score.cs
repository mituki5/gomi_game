using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreText; // スコアテキスト

    private GameObject trash;        
    private GameObject plastic;
    private GameObject bottle;
    public static int score = 0;

    [SerializeField] public GameObject Sound4; // 間違った場所にゴミが入った音

    void Start()
    {
        ScoreText.text = $"スコア：{score.ToString("D3")}";

        // ヒエラルキーから探す
        trash = GameObject.Find("Moeru_Gomibako");
        plastic = GameObject.Find("Plastic_Gomibako");
        bottle = GameObject.Find("Bottle_Gomibako");

        score = PlayerPrefs.GetInt("SCORE", 0);

        Sound4.SetActive(false);

    }

    // 削除時の処理
    void OnDestroy()
    {
        // スコアを保存
        //PlayerPrefs.SetInt("SCORE", score);
        //PlayerPrefs.Save();
    }

    void Update()
    {
        // 紙くずが入ったら
        if (trash.GetComponent<TrashBox>().isEnter == true)
        {
            score += 30;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            trash.GetComponent<TrashBox>().isEnter = false;
        }

        // 弁当箱が入ったら
        if (plastic.GetComponent<PlasticBox>().isEnter_p == true)
        {
            score += 80;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            plastic.GetComponent<PlasticBox>().isEnter_p = false;
        }

        // キャップが入ったら
        if (plastic.GetComponent<PlasticBox>().isEnter_c == true)
        {
            score += 20;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            plastic.GetComponent<PlasticBox>().isEnter_c = false;
        }

        // ペットボトルが入ったら
        if (bottle.GetComponent<BottleBox>().isEnter_p == true)
        {
            score += 80;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            bottle.GetComponent<BottleBox>().isEnter_p = false;
        }

        // ボトルが入ったら
        if (bottle.GetComponent<BottleBox>().isEnter_b == true)
        {
            score += 100;
            ScoreText.text = $"スコア：{score.ToString("D3")}";
            bottle.GetComponent<BottleBox>().isEnter_b = false;
        }

        // 間違ったところに入ったら
        if (trash.GetComponent<TrashBox>().mistake == true || plastic.GetComponent<PlasticBox>().mistake == true || bottle.GetComponent<BottleBox>().mistake == true)
        {
            Sound4.SetActive(true);
            if (score > 0)
            {
                score -= 10;
                ScoreText.text = $"スコア：{score.ToString("D3")}";
                trash.GetComponent<TrashBox>().mistake = false;
                plastic.GetComponent<PlasticBox>().mistake = false;
                bottle.GetComponent<BottleBox>().mistake = false;

            }
        }
        Sound4.SetActive(false);

        //if (PlayerPrefs.HasKey("SCORE"))
        //{
        //    PlayerPrefs.DeleteKey("SCORE");
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("SCORE", score);
        //    PlayerPrefs.Save();
        //}]

        if (SceneManager.GetActiveScene().name == "GameScene 1")
        {
            score = 0;
        }
    }
}
