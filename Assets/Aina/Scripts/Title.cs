using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private GameObject Trash;

    void Start()
    {
        Trash = GameObject.Find("Moeru_Gomibako");
    }

    void Update()
    {
        if (Trash.GetComponent<TrashBox>().isEnter == true)
        {
            SceneManager.LoadScene("GameScene 1");
        }
    }
}
