using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float _Rotate;
    public float max = 180;
    public float min = -180;
    //左回り
    public void Rotateringleft()
    {
        transform.Rotate(0, 0, 1);
    }

    //右回り
    public void RotateringRight()
    {
        transform.Rotate(0, 0, -1);
    }
}
