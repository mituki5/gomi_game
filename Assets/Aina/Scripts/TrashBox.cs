using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    [SerializeField] private GameObject trash;
    [SerializeField] private GameObject plastic;
    [SerializeField] private GameObject bottle;
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
                trash.SetActive(false);
                break;
            case "plasticgomi":
                plastic.SetActive(false);
                break;
            case "plasticbottle":
                plastic.SetActive(false);
                break;

        }
    }
}
