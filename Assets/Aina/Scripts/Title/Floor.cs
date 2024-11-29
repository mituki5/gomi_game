using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject StartBall; // スタートボールオブジェクト
    [SerializeField] public bool preparation; // スタートボールが準備できているかどうか

    void Start()
    {
        // ヒエラルキーから探す
        StartBall = GameObject.Find("StartBall");

        preparation = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // スタートボールに当たったら
        if (other.gameObject.tag == "startball")
        {
            Destroy(other.gameObject);
            Invoke(nameof(StartBallPreparation), 0.3f); // 0.5f待つ
        }
    }

    void StartBallPreparation()
    {
        StartBall.SetActive(true);
        preparation = true;
    }
}
