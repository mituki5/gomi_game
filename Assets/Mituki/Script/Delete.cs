using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private int Objectcount;
    private ThrowingPower ThrowingPower;

    public void Destroy()
    {
        //ゴミが消える条件
        Vector3 pos = new Vector3(0, 0, 30);
        if (this.transform.position.z > pos.z)
        {
            Destroy(this.gameObject);
        }
    }

    public void Deprive()
    {
        //ゴミについたThrowingpowerの無効化
        
    }
}
