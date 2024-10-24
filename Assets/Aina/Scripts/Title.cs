using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private GameObject Trash;

    void Start()
    {
        Trash = GameObject.Find("trash");
    }

    void Update()
    {
        if (Trash.GetComponent<Moerugomi>().isEnter == true)
        {
            SceneManager.LoadScene("GameScene 1");
        }
    }
}
