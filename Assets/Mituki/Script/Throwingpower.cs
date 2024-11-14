using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;

public class ThrowingPower : MonoBehaviour
{
    public float Power = 0;
    public float MinPower = 0;
    public float MaxPower = 100;
    public float Angle = 50.0f;
    public GameObject Trash_box;
    public GameObject Player;
    public GameObject targetobject;

    public bool landing = true;
    public bool shot = true;
    public bool canShot = false;
    public bool powercount  = false;
    public bool powercount10 = true;

    private kinds kindScript;

    public void SetScript(GameObject trashBox, kinds kind, bool canShot)
    {
        Trash_box = trashBox;
        kindScript = kind;
        this.canShot = canShot;
    }

    private GameObject time;
    private void Start()
    {
        time = GameObject.Find("TimeObject");
    }
    // Update is called once per frame
    void Update()
    {
        //if(time.GetComponent<TimeCounter>().start == false){
        if (!this.canShot) return;
        Key();

        if (Input.GetMouseButtonUp(0))
        {
            if (powercount10 == false)
            {
                Debug.Log(Power + "放した");
                //Throw();
                TargetDistance();
                Gauge();

                //BoxCollider boxCollider = GetComponent<BoxCollider>();
                //boxCollider.isTrigger = true;

                Power = 0;
                landing = false;
                shot = false;
                powercount10 = true;
            }
        }
    //}
    }


    /// <summary>
    /// 押している間Powerをためる関数（繰り返す）
    /// </summary>
    public void Key()
    {
        
        if (Input.GetMouseButton(0))
        {
            if (powercount == false)
            {
                if ((int)Power <= MaxPower)
                {
                    Power += 0.1f;
                    Debug.Log(Power + "増えてる");
                    if ((int)Power == 10)
                    {
                        powercount10 = false;
                    }
                    if ((int)Power == MaxPower)
                    {
                        powercount = true;
                    }    
                }
            }
            if (powercount == true)
            {
                Power -= 0.1f;
                Debug.Log(Power + "減ってる");
                if ((int)Power == MinPower)
                {
                    powercount = false;
                }
            }
        }
    }

    public void TargetDistance()
    {
        targetobject.transform.position = new Vector3(0, 0, Power);
    }


    /// <summary>
    /// 投げる関数
    /// </summary>
    public void Gauge()
    {
            // 標的の座標
            Vector3 targetPosition = targetobject.transform.position;
        //Debug.Log(targetPosition);

            // 射出角度
            float angle = Angle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // 射出
          Debug.Log(velocity);
        Debug.Log(kindScript.weight);
          Rigidbody rb = GetComponent<Rigidbody>();
           rb.AddForce(velocity * rb.mass / kindScript.weight, ForceMode.Impulse);
        rb.useGravity = true;

    }

    /// <summary>
    /// 標的に命中する射出速度の計算
    /// </summary>
    /// <param name="pointA">射出開始座標</param>
    /// <param name="pointB">標的の座標</param>
    /// <returns>射出速度</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));



        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
