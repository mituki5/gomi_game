using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTrash : MonoBehaviour
{
    [SerializeField] private GameObject TrashImage;
    [SerializeField] private GameObject PlasticImage;
    [SerializeField] private GameObject BottleImage;

    private GameObject Object;
    public int index;

    void Start()
    {
        TrashImage.SetActive(false);
        PlasticImage.SetActive(false);
        BottleImage.SetActive(false);

        Object = GameObject.Find("GameObject");
    }

    void Update()
    {
    }
}
