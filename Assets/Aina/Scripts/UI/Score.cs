using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreText; // �X�R�A�e�L�X�g

    private GameObject trash;        
    private GameObject plastic;
    private GameObject bottle;
    public static int score = 0;

    [SerializeField] public GameObject Sound4; // �Ԉ�����ꏊ�ɃS�~����������

    void Start()
    {
        ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";

        // �q�G�����L�[����T��
        trash = GameObject.Find("Moeru_Gomibako");
        plastic = GameObject.Find("Plastic_Gomibako");
        bottle = GameObject.Find("Bottle_Gomibako");

        score = PlayerPrefs.GetInt("SCORE", 0);

        Sound4.SetActive(false);

    }

    // �폜���̏���
    void OnDestroy()
    {
        // �X�R�A��ۑ�
        //PlayerPrefs.SetInt("SCORE", score);
        //PlayerPrefs.Save();
    }

    void Update()
    {
        // ����������������
        if (trash.GetComponent<TrashBox>().isEnter == true)
        {
            score += 30;
            ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";
            trash.GetComponent<TrashBox>().isEnter = false;
        }

        // �ٓ�������������
        if (plastic.GetComponent<PlasticBox>().isEnter_p == true)
        {
            score += 80;
            ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";
            plastic.GetComponent<PlasticBox>().isEnter_p = false;
        }

        // �L���b�v����������
        if (plastic.GetComponent<PlasticBox>().isEnter_c == true)
        {
            score += 20;
            ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";
            plastic.GetComponent<PlasticBox>().isEnter_c = false;
        }

        // �y�b�g�{�g������������
        if (bottle.GetComponent<BottleBox>().isEnter_p == true)
        {
            score += 80;
            ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";
            bottle.GetComponent<BottleBox>().isEnter_p = false;
        }

        // �{�g������������
        if (bottle.GetComponent<BottleBox>().isEnter_b == true)
        {
            score += 100;
            ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";
            bottle.GetComponent<BottleBox>().isEnter_b = false;
        }

        // �Ԉ�����Ƃ���ɓ�������
        if (trash.GetComponent<TrashBox>().mistake == true || plastic.GetComponent<PlasticBox>().mistake == true || bottle.GetComponent<BottleBox>().mistake == true)
        {
            Sound4.SetActive(true);
            if (score > 0)
            {
                score -= 10;
                ScoreText.text = $"�X�R�A�F{score.ToString("D3")}";
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
