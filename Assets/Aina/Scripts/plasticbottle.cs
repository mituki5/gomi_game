using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class plasticbottle : MonoBehaviour
{
    [SerializeField] private GameObject Trash3;
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
        if (collision.gameObject.tag == "plasticbottle_box")
        {
            Debug.Log("“ü‚Á‚½!");
            isEnter = true;
            //Destroy(gameObject);
            Trash3.SetActive(false);
        }
    }
}
