using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotate;
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

    //¶‰ñ‚è
    public void Rotateringleft()
    {
        transform.Rotate(0, 0, 1);
    }

    //‰E‰ñ‚è
    public void RotateringRight()
    {
        transform.Rotate(0, 0, -1);
    }

    //d‚¢‚Æ‚±‚ğ’†S‚É
    public void Rotatering1()
    {
        rotate = transform.eulerAngles.z;
        if (rotate <= max)
        {
            transform.Rotate(0, 0, -1);
        }
        else if(rotate >= min)
        {
            transform.Rotate(0, 0, 1);
        }
    }
}
