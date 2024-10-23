using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;

public class Throwingpoewr : MonoBehaviour
{
    public float Power = 0;
    public GameObject Trash_box;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
    }

    
    // Update is called once per frame
    void Update()
    {
        if(Power < 100)
        {
            if (Input.GetMouseButton(0))
            {
                Power += 1f / 10;
                Debug.Log(Power + "ëùÇ¶ÇƒÇÈ");
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(Power + "ï˙ÇµÇΩ");
                Throw();
                //Gauge();

                Power = 0;

            }
        }
    }

    /// <summary>
    /// ìäÇ∞ÇÈä÷êî
    /// </summary>
    public void Throw()
    {
        kinds _kindsScript = GetComponent<kinds>();
        Debug.Log(_kindsScript.firstObject.name);
        Debug.Log(_kindsScript._name);
        if (_kindsScript.firstObject.name == _kindsScript._name)
        {
            //óÕÇÃï˚å¸
            Vector3 pos = Trash_box.transform.position * Power - Player.transform.position;
            Vector3 forceDirection = new Vector3(0, Power / _kindsScript.weight * 9.8f  / 100 , Power / 100);
            //if(pos.z <= forceDirection.z)
            //{
            //    forceDirection = new Vector3(0, Power  * 9.8f * 3, Power);
            //}
            float forceMagnitude = 10.0f;
            Vector3 force = forceMagnitude * forceDirection;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.Impulse);
        }


    }


    //public void Gauge()
    //{   
    //    Vector3 youpos = Trash_box.transform.position;
    //    Vector3 mypos = Player.transform.position;
    //    Vector3 V;
    //    //time = youpos.z / mypos.z;
    //    V.z = Mathf.Cos(Mathf.Deg2Rad * youpos.z) * Power * time;
    //    V.y = (float)((Mathf.Sign(Mathf.Deg2Rad * youpos.y) * Power) * time - (1 / 2) * 9.8 * Mathf.Pow(time, 2));
    //    gameObject.transform.position = new Vector3(0, -V.z, V.y);        rb.GetComponent<Rigidbody>();
    //    //rb.useGravity = false;
    //    //rb.AddForce(0, V.y, V.z);
    //}
}
