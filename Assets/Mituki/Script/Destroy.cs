using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private int Objectcount;
    private ThrowingPower ThrowingPower;
    // Start is called before the first frame update
    void Start()
    {
    }

    //ÉSÉ~Ç™è¡Ç¶ÇÈèåè
    void Update()
    {
        //èÍèä
        Vector3 pos = new Vector3(0, 0, 30);
        if (this.transform.position.z > pos.z)
        {
            Destroy(this.gameObject);
        }
        //êî
        if(ThrowingPower.shot == false)
        {
            if(Objectcount == 10)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
