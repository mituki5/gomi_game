using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TMPro.EditorUtilities;
using UnityEditor.Animations;
using UnityEngine;

public class ThrowingPower : MonoBehaviour
{
    [Header("Power Settings")]
    public float Power = 0; //現在のPower
    private float MinPower = 0;//最大Power
    private float MaxPower = 100; //最小Power
    public float PowerIncreaseRate = 0.1f;
    public float PowerDecreaseRate = 0.6f;
    private bool isIncreasingPower = true; //Powerを増加させるフラグ
    private bool NegatePower = true; //無効化
    public float SpeedMultiplier = 2.0f; // 射出速度の倍率
    private float Angle = 40.0f;

    [Header("References")]
    public GameObject TrashBox;
    public GameObject Player;
    public GameObject TargetObject;

    private GameObject time;
    private GameObject child;

    public bool iscanShoot = true;
    public bool iscanRotate = true;

    //public bool landing = true;
    //public bool shot = true;
    //public bool powercount  = false;
    //public bool powercount10 = true;

    private Rigidbody rb;
    private kinds kindScript;



    public void SetScript(GameObject trashBox, kinds kind, bool iscanShoot)
    {
        TrashBox = trashBox;
        kindScript = kind;
        this.iscanShoot = iscanShoot;
    }
    private void ResetThrow()
    {
        Power = 0;
        iscanShoot = true;
        isIncreasingPower = true;
        iscanRotate = true;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = GameObject.Find("TimeObject");
    }
    // Update is called once per frame
    void Update()
    {
        //if(time.GetComponent<TimeCounter>().start == true)
        {
            if (!this.iscanShoot) return;
            HandlePowerInput();
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log(Power + "放した");
                    TargetDistance();
                    Gauge();
                    ResetThrow();
                    iscanShoot = false;
                    iscanRotate = false;
                    Power = 0;
                kindScript.isGround = false;
                    ThrowingPower.Destroy(this);
                
            }
        }
    }

    public void CheckPowerStatus()
    {
        // PowerがMaxPowerに達したら増加を停止
        if ((int)Power >= MaxPower)
        {
            isIncreasingPower = false;
        }
        // PowerがMinPowerに達したら減少を停止
        else if ((int)Power <= MinPower)
        {
            isIncreasingPower = true;
        }

        // Powerが0または10以下の場合、NegatePowerフラグを設定
        if ((int)Power <= 10 || (int)Power == 0)
        {
            NegatePower = false;
            if (isIncreasingPower || !isIncreasingPower)
            {
                NegatePower = true; // 増加中または、減少中ならNegatePowerをtrueに設定
            }
        }
    }

    /// <summary>
    /// マウスを押している間にPowerを増減する処理
    /// </summary>
    public void HandlePowerInput()
    {
        if (Input.GetMouseButton(0)) // マウス左ボタンが押されている間
        {
            CheckPowerStatus();
            if (isIncreasingPower)
            {
                // Powerを増加させる
                Power += PowerIncreaseRate;
                //Debug.Log(Power + " 増えてる");

                // Powerが50以上の場合、増加速度を上げる
                if ((int)Power >= 50)
                {
                    Power += PowerDecreaseRate; // 50を超えると速く増える
                    //Debug.Log(Power + " 増えてる");
                }
                // PowerがMaxPowerを超えないように制限
                if ((int)Power == MaxPower)
                {
                    Power = MaxPower;
                }
            }
            else if(!isIncreasingPower)
            {
                // Powerを減少させる
                Power -= PowerIncreaseRate;
                //Debug.Log(Power + " 減ってる");
                // Powerが50以上の場合、減少速度を上げる
                if ((int)Power >= 50)
                {
                    Power -= PowerDecreaseRate; // 50を超えると速く減る
                    //Debug.Log(Power + " 減ってる");
                }
                // PowerがMinPowerを下回らないように制限
                if ((int)Power == MinPower)
                {
                    Power = MinPower;
                }         
            }
        }
    }


    public void TargetDistance()
    {
        TargetObject.transform.position = new Vector3(0, 0, Power);
    }


    /// <summary>
    /// 投げる関数
    /// </summary>
    public void Gauge()
    {
        if (kindScript.firstObject == null) return;
            // 標的の座標
            Vector3 targetPosition = TargetObject.transform.position;
            // 射出角度
            float angle = Angle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);


        // 射出
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

        // 射出速度を計算
        //float g = -Physics.gravity.y; // 重力加速度
        //float tan = Mathf.Tan(rad);

        // 速度を増加させるためのスケールファクター
        float speedMultiplier = 1.5f; // 1より大きい値を設定して速度を上げる

        // 必要な初速度を計算（公式に基づく）
        float initialSpeed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        // 初速度に倍率を適用
        initialSpeed *= speedMultiplier;
        Debug.Log(initialSpeed);
        if (float.IsNaN(initialSpeed))
        {
            Debug.Log("失敗");
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;

        }
        else
        {
            // 射出速度を算出
            //Vector3 direction = new Vector3(pointB.x - pointA.x, x * tan, pointB.z - pointA.z).normalized;
            //return direction * initialSpeed;

            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * initialSpeed);

        }
    }
}
