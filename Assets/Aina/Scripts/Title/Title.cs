using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private GameObject Trash;
    //private GameObject time;

    public bool start;

    void Start()
    {
        Trash = GameObject.Find("Moeru_Gomibako");
        //time = GameObject.Find("TimeObject");
        //time.GetComponent<TimeCounter>().start = true;

        start = true;
    }

    void Update()
    {
        if (Trash.GetComponent<TrashBox>().isEnter == true)
        {
            SceneManager.LoadScene("GameScene 1");
            //time.GetComponent<TimeCounter>().start = false;

            start =  false;
        }
    }
}
