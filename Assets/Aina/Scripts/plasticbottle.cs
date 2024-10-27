using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Plasticbottle : MonoBehaviour
{
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
        if (collision.gameObject.tag == "plasticbottle_box")
        {
            Debug.Log("“ü‚Á‚½!");
            isEnter = true;
            //Destroy(gameObject);
            bottle.SetActive(false);
        }
        if (collision.gameObject.tag == "plasticgomi_box" || collision.gameObject.tag == "moerugomi_box")
        {
            Debug.Log("ŠÔˆá‚¦‚½");
            mistake = true;
            gameObject.SetActive(false);
        }
    }
}
