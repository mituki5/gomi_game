using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private float speed = 3;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);

        if (transform.position.x <= -10f)
        {
            transform.position = new Vector3(14, 4, 0);
        }
    }
}
