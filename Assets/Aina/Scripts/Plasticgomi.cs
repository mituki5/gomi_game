using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plasticgomi : MonoBehaviour
{
    [SerializeField] private GameObject plastic;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plasticgomi_box")
        {
            Debug.Log("“ü‚Á‚½!");
            isEnter = true;
            //Destroy(gameObject);
            plastic.SetActive(false);
        }
        if (collision.gameObject.tag == "moerugomi_box" || collision.gameObject.tag == "plasticbottle_box")
        {
            Debug.Log("ŠÔˆá‚¦‚½");
            mistake = true;
            gameObject.SetActive(false);
        }
    }
}
