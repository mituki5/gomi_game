using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSound : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    //[SerializeField]
    //private AudioClip clip1; // 投げた時の音
     
    [SerializeField]
    private AudioClip clip2; // 正しい場所にゴミが入った音   

    //private GameObject StartBall;
    private GameObject Trash;

    void Start()
    {
        //StartBall = GameObject.Find("Floor");
        Trash = GameObject.Find("Moeru_Gomibako");
    }

    void Update()
    {
        //if (StartBall.GetComponent<Floor>().preparation == true)
        //{
        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        soundManager.Play(clip1);
        //    }
        //}

        if (Trash.GetComponent<TrashBox>().isEnter2 == true)
        {
            soundManager.Play(clip2);
        }
    }
}
