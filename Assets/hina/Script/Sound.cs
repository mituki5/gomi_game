using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource source; //スピーカー・CDプレイヤー

    [SerializeField]
    private AudioClip clip1; //音源データ1

    [SerializeField]
    private AudioClip clip2; //音源データ2

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //左クリック
        {
            source.clip = clip1; //再生したいclipを指定して
            source.Play(); //再生
        }
        if (Input.GetMouseButtonDown(1)) //右クリック
        {
            source.clip = clip2; //再生したいclipを指定して
            source.Play(); //再生
        }
    }
}
