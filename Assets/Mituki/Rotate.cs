using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Rotate retate;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Rotatering();
        }

    }
    public void Rotatering()
    {
        transform.Rotate(0,0,1);
    }
}
