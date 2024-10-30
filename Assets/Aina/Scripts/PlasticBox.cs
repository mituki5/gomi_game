using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlasticBox : MonoBehaviour
{
    [SerializeField] private GameObject trash;
    [SerializeField] private GameObject plastic;
    [SerializeField] private GameObject bottle;
    public bool isEnter;
    public bool mistake;
    void Start()
    {
        isEnter = false;
        mistake = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "moerugomi")
        {
            Debug.Log("燃えるゴミ入った");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticgomi")
        {
            Debug.Log("プラゴミ入った");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticbottle")
        {
            Debug.Log("ペットボトル入った");
            isEnter = true;
            Destroy(collision.gameObject);
        }*/
        switch (collision.gameObject.tag)
        {
            case "moerugomi":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(collision.gameObject);
                break;
            case "plasticgomi":
                isEnter = true;
                Debug.Log("プラゴミ入った");
                Destroy(collision.gameObject);
                break;
            case "plasticbottle":
                mistake = true;
                Debug.Log("間違えた");
                Destroy(collision.gameObject);
                break;
        }
    }
}
