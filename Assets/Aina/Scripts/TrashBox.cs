using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    [SerializeField] private GameObject Trash;
    [SerializeField] private GameObject Trash2;
    public bool isEnter;
    void Start()
    {
        isEnter = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("“ü‚Á‚½!");
        isEnter = true;
        switch (collision.gameObject.tag)
        {
            case "moerugomi":
                Trash.SetActive(false);
                break;
            case "plasticgomi":
                Trash2.SetActive(false);
                break;

        }
    }
}
