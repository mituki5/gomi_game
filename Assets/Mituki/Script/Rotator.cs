using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateX = 0;
    [SerializeField]
    private float rotateY = 0;
    [SerializeField]
    private float rotateZ = 0;

    private ThrowingPower throwingPower;

    private void Start()
    {
        throwingPower = GetComponent<ThrowingPower>();
    }

    private void Update()
    {
        if(throwingPower.iscanRotate == false)
        {
            gameObject.transform.Rotate(new Vector3(rotateX,rotateY,rotateZ) * Time.deltaTime);
        }
    }
}
