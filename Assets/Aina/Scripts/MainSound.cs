using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSound : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    [SerializeField] private AudioClip clip1; // BGM  
    [SerializeField] private AudioClip clip2; // スタートした瞬間の音
    [SerializeField] private AudioClip clip3; // 正しい場所にゴミが入った音
    [SerializeField] private AudioClip clip4; // 間違った場所にゴミが入った音
    [SerializeField] private AudioClip clip5; // ゲームの残り時間を知らせる音

    bool count2;
    bool count4;

    private GameObject _time;

    private GameObject trash;
    private GameObject plastic;
    private GameObject bottle;
    void Start()
    {
        _time = GameObject.Find("TimeObject");
        count2 = false;
        count4 = false;

        trash = GameObject.Find("Moeru_Gomibako");
        plastic = GameObject.Find("Plastic_Gomibako");
        bottle = GameObject.Find("Bottle_Gomibako");
    }

    void Update()
    {
        Invoke(nameof(SoundPlay), 3.0f);

        if (trash.GetComponent<TrashBox>().isEnter2 == true ||
            trash.GetComponent<TrashBox>().isEnter == true ||
            plastic.GetComponent<PlasticBox>().isEnter_p == true ||
            plastic.GetComponent<PlasticBox>().isEnter_c == true ||
            bottle.GetComponent<BottleBox>().isEnter_p == true ||
            bottle.GetComponent<BottleBox>().isEnter_b == true)
        {
            soundManager.Play(clip3);
        }

        if (trash.GetComponent<TrashBox>().mistake == true || 
            plastic.GetComponent<PlasticBox>().mistake == true || 
            bottle.GetComponent<BottleBox>().mistake == true)
        {
            if (count4 == false)
            {
                soundManager.Play(clip4);
                count4 = true;

            }
        }
    }

    void SoundPlay()
    {
        //soundManager.Play(clip1);
        if (count2 == false)
        {
            soundManager.Play(clip2);
            count2 = true;
        }
    }
}
