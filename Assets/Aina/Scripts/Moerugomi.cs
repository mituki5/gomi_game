using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moerugomi : MonoBehaviour
{
    [SerializeField] Text ScoreText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "moerugomi_box")
        {
            Debug.Log("������!");
            Destroy(gameObject);
            Score scorescript = GetComponent<Score>();
            scorescript.score = 30;
            ScoreText.text = $"�X�R�A�F{scorescript.score.ToString("D3")}";
        }
    }
}
