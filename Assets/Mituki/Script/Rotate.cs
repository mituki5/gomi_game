using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float _Rotate;
    public float max = 180;
    public float min = -180;
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(0, 0, Random.Range(min,max));
            Rotatering1();
        }

    }

    //�����
    public void Rotateringleft()
    {
        transform.Rotate(0, 0, 1);
    }

    //�E���
    public void RotateringRight()
    {
        transform.Rotate(0, 0, -1);
    }

    //�d���Ƃ��𒆐S��
    public void Rotatering1()
    {
        _Rotate = transform.eulerAngles.z;
        if (_Rotate <= max)
        {
            transform.Rotate(0, 0, -1);
        }
        else if(_Rotate >= min)
        {
            transform.Rotate(0, 0, 1);
        }
    }
}
