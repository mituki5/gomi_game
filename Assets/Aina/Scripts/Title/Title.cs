using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private GameObject Trash; // �S�~���I�u�W�F�N�g
    //private GameObject time;

    public bool start; // �Q�[�����������ǂ���

    void Start()
    {
        // �q�G�����L�[����T��
        Trash = GameObject.Find("Moeru_Gomibako");
        //time = GameObject.Find("TimeObject");
        //time.GetComponent<TimeCounter>().start = true;

        // ������V�[����Title�̂Ƃ�
        if (SceneManager.GetActiveScene().name == "Title")
        {
            start = true;
        }
        else
        {
            start = false;
        }
    }

    void Update()
    {
        //if (SceneManager.GetActiveScene().name == "GameScene 1")
        //{
        //    start = false;
        //}

        // �X�^�[�g�{�[������������
        if (Trash.GetComponent<TrashBox>().isEnter2 == true)
        {
            SceneManager.LoadScene("GameScene 1"); // �Q�[���V�[���Ɉړ�
            //time.GetComponent<TimeCounter>().start = false;

            start =  false;
        }
    }
}
