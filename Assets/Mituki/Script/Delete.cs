using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private int Objectcount;
    private ThrowingPower ThrowingPower;

    public void Destroy()
    {
        //ƒSƒ~‚ªÁ‚¦‚éðŒ
        Vector3 pos = new Vector3(0, 0, 30);
        if (this.transform.position.z > pos.z)
        {
            Destroy(this.gameObject);
        }
    }

    public void Deprive()
    {
        //ƒSƒ~‚É‚Â‚¢‚½Throwingpower‚Ì–³Œø‰»
        
    }
}
