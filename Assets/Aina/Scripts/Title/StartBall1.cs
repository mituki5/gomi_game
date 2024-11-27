using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBall1 : MonoBehaviour
{
    public GameObject StartBall;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartBall.SetActive(false);
        }
    }
}
