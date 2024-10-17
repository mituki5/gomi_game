using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plasticgomi : MonoBehaviour
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
        if (collision.gameObject.tag == "plasticgomi_box")
        {
            Debug.Log("入った!");
            Destroy(gameObject);
            Score scorescript = GetComponent<Score>();
            scorescript.score = 80;
            ScoreText.text = $"スコア：{scorescript.score.ToString("D3")}";
        }
    }
}
