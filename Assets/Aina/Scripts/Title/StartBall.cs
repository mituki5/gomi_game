using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBall : MonoBehaviour
{
    [SerializeField] private GameObject startball;
    [SerializeField] private GameObject gameobject;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            //Destroy(gameObject);
            for (int i = 0; i < 2; i++)
            {
                GameObject obj = (GameObject)Resources.Load("StartBall1");
                Instantiate(obj, new Vector3(0.0f, -2.0f, -2.0f), Quaternion.identity);
                GameObject empty_obj = (GameObject)Resources.Load("GameObject");
                Instantiate(empty_obj, new Vector3(0.0f, -2.0f, -2.0f), Quaternion.identity);
            }
        }
    }
}
