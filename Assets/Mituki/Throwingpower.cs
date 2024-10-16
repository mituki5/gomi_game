using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Power = 0;
    public GameObject Trash_box;
    public GameObject Player;
    public float time;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Power += 0.1f;
            Debug.Log(Power + "ëùÇ¶ÇƒÇÈ");

        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(Power + "ï˙ÇµÇΩ");
            //Throw();
            Gauge();
            
            Power = 0;

        }
    }

    /// <summary>
    /// ìäÇ∞ÇÈä÷êî
    /// </summary>
    public void Throw()
    {
        //óÕÇÃï˚å¸
        Vector3 forceDirection = new Vector3(0, Power, Power);
        float forceMagnitude = 10.0f;
        Vector3 force = forceMagnitude * forceDirection;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(force, ForceMode.Impulse);
    }


    public void Gauge()
    {
        Vector3 youpos = Trash_box.transform.position;
        Vector3 mypos = Player.transform.position;
        Vector3 V;
        time = Power / mypos.z;
        V.z = mypos.z * time;
        V.y = time *2 + mypos.y * time;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, V.y, V.z);

    }
}
