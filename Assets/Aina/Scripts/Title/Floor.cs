using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject StartBall;
    [SerializeField] public bool preparation;

    void Start()
    {
        StartBall = GameObject.Find("StartBall");
        preparation = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "startball")
        {
            Destroy(other.gameObject);
            Invoke(nameof(StartBallActive), 0.5f);
        }
    }

    void StartBallActive()
    {
        StartBall.SetActive(true);
        preparation = true;
    }
}
