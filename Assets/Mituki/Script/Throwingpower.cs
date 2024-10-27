using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;

public class ThrowingPower : MonoBehaviour
{
    public float Power = 0;
    public GameObject Trash_box;
    public GameObject Player;

    public bool landing = true;
    public bool shot = true;
    public bool canShot = false;

    private kinds kindScript;


    public void SetScript(GameObject trashBox, kinds kind, bool canShot)
    {
        Trash_box = trashBox;
        kindScript = kind;
        this.canShot = canShot;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!this.canShot) return;
        if(Power < 100f)
        {
            if (Input.GetMouseButton(0))
            {
                Power += 0.1f;
                Debug.Log(Power + "ëùÇ¶ÇƒÇÈ");
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(Power + "ï˙ÇµÇΩ");
                Throw();
                //Gauge();

                Power = 0;
                landing = false;
                shot = false;
            }
        }
    }

    /// <summary>
    /// ìäÇ∞ÇÈä÷êî
    /// </summary>
    public void Throw()
    {
        //Debug.Log(kindScript.firstObject.name);
        //Debug.Log(kindScript.weight);
        //if (kindScript.firstObject.name == kindScript._name[kindScript.index])
        //{
           
        //}
        //óÕÇÃï˚å¸
        //Trash_box = GameObject.Find("TrashBox");
        //Vector3 pos = Trash_box.transform.position * Power - Player.transform.position;
        Vector3 forceDirection = new Vector3(0, Power / kindScript.weight * 9.8f / 100f, Power / 100f);
        //if(pos.z <= forceDirection.z)
        //{
        //    forceDirection = new Vector3(0, Power  * 9.8f * 3, Power);
        //}
        float forceMagnitude = 10.0f;
        Vector3 force = forceMagnitude * forceDirection;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
        rb.useGravity = true;

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
