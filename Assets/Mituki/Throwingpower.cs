using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Power = 0;
    public bool ThowKey = false;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Power += 0.01f;
            Debug.Log(Power + "増えてる");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(Power + "放した");
            Throw();
            Power = 0;

        }
    }

    /// <summary>
    /// 投げる関数
    /// </summary>
    public void Throw()
    {
        //力の方向
        Vector3 forceDirection = new Vector3(0, Power / 10, Power / 10);
        float forceMagnitude = 10.0f;
        Vector3 force = forceMagnitude * forceDirection;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
    }

    //public void ThrowingPower()
    //{
    //    switch (Power)
    //    {
    //        case 0:
    //            if (ThowKey)
    //            {

    //            }
    //        break;
    //    }
    //}

    public void Gauge()
    {

    }
}
