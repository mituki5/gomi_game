using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Moerugomi : MonoBehaviour
{
    [SerializeField] private GameObject Trash;
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
        if (collision.gameObject.tag == "moerugomi_box")
        {
            Debug.Log("“ü‚Á‚½!");
            isEnter = true;
            //Destroy(gameObject);
            Trash.SetActive(false);
        }
    }
}
