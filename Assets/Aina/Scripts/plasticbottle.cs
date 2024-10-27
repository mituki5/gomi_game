using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Plasticbottle : MonoBehaviour
{
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
        if (collision.gameObject.tag == "plasticbottle_box")
        {
            Debug.Log("“ü‚Á‚½!");
            isEnter = true;
            //Destroy(gameObject);
            bottle.SetActive(false);
        }
    }
}
