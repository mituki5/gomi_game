using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBallScript : MonoBehaviour
{
    public GameObject StartBall; // スタートボールオブジェクト
    void Update()
    {
        // マウス左クリックして離したら
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartBall.SetActive(false);
        }
    }
}
