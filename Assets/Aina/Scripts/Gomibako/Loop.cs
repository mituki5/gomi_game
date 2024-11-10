using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private float speed = 5.0f;
    [SerializeField] int count = 1;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform pointC;

    private GameObject time;

    private void Start()
    {
        time = GameObject.Find("TimeObject");
    }

    void Update()
    {
        if (time.GetComponent<TimeCounter>().start == true) 
        {
            if (count == 0)
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            else if (count == 1)
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            else if (count == 2)
                transform.position = Vector3.MoveTowards(transform.position, pointC.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PointA")
            count = 1;
        else if (other.gameObject.name == "PointB")
            count = 2;
        else if (other.gameObject.name == "PointC")
            count = 0;
    }
}