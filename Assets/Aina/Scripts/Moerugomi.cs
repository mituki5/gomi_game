using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Moerugomi : MonoBehaviour
{
    [SerializeField] private GameObject trash;

    public bool isEnter;
    public bool mistake;
    void Start()
    {
        /*trash = this.transform.Find("trash").gameObject;
        trash.GetComponent<Moerugomi>().gameObject = "”R‚¦‚éƒSƒ~";*/

        isEnter = false;
        mistake = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "moerugomi_box")
        {
            Debug.Log("“ü‚Á‚½!");
            isEnter = true;
            //Destroy(gameObject);
            trash.SetActive(false);
        }
        if (collision.gameObject.tag == "plasticgomi_box" || collision.gameObject.tag == "plasticbottle_box")
        {
            Debug.Log("ŠÔˆá‚¦‚½");
            mistake = true;
            gameObject.SetActive(false);
        }
    }
}
