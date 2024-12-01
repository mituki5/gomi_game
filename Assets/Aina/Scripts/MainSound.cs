using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSound : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    [SerializeField] private AudioClip clip2; // スタートした瞬間の音
    [SerializeField] private AudioClip clip3; // 正しい場所にゴミが入った音
    [SerializeField] private AudioClip clip4; // 間違った場所にゴミが入った音

    AudioSource source;

    bool count2;
    bool count4;

    private GameObject _time;

    private GameObject trash;
    private GameObject plastic;
    private GameObject bottle;
    void Start()
    {
        _time = GameObject.Find("TimeObject");

        //source = GetComponent<AudioSource>();
        //source.Play();

        count2 = false;
        count4 = false;

        trash = GameObject.Find("Moeru_Gomibako");
        plastic = GameObject.Find("Plastic_Gomibako");
        bottle = GameObject.Find("Bottle_Gomibako");
    }

    void Update()
    {
        Invoke(nameof(SoundPlay), 2.8f); 

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
        if (count2 == false)
        {
            soundManager.Play(clip2);
            count2 = true;
        }
    }
}
