using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Power = 1.0f;
    public bool ThowKey = false;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        ThowKey = Input.GetMouseButtonDown(0);
        if (Input.GetMouseButtonDown(0))
        {
            timer += Time.deltaTime;
                if(Power < 100){

                Power = timer; 
                    Throw();
                }
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
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
    }

    public void ThrowingPower()
    {
        switch (Power)
        {
            case 0:
                if (ThowKey)
                {

                }
            break;
        }
    }

    public void Gauge()
    {

    }
}
