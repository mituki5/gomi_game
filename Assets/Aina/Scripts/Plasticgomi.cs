using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plasticgomi : MonoBehaviour
{
    [SerializeField] private GameObject plastic;
    public bool isEnter;

    void Start()
    {
        isEnter = false;
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
    }
}
