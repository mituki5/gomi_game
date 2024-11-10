using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
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
            Debug.Log("”R‚¦‚éƒSƒ~“ü‚Á‚½");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticgomi")
        {
            Debug.Log("ƒvƒ‰ƒSƒ~“ü‚Á‚½");
            isEnter = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "plasticbottle")
        {
            Debug.Log("ƒyƒbƒgƒ{ƒgƒ‹“ü‚Á‚½");
            isEnter = true;
            Destroy(collision.gameObject);
        }*/
        switch (collision.gameObject.tag)
        {
            case "moerugomi":
                isEnter = true;
                Debug.Log("”R‚¦‚éƒSƒ~“ü‚Á‚½");
                Destroy(collision.gameObject);
                break;
            case "plasticgomi":
                mistake = true;
                Debug.Log("ŠÔˆá‚¦‚½");
                Destroy(collision.gameObject);
                break;
            case "plasticbottle":
                mistake = true;
                Debug.Log("ŠÔˆá‚¦‚½");
                Destroy(collision.gameObject);
                break;
            case "cap":
                mistake = true;
                Debug.Log("ŠÔˆá‚¦‚½");
                Destroy(collision.gameObject);
                break;
            case "bottle":
                mistake = true;
                Debug.Log("ŠÔˆá‚¦‚½");
                Destroy(collision.gameObject);
                break;
        }
    }
}
