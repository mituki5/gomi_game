using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowingScript1 : MonoBehaviour
{
    public float Power = 0;
    public float MinPower = 0;
    public float MaxPower = 100;
    public bool powercount = false;
    public bool powercount10 = true;

    /// <summary>
    /// 射出するオブジェクト
    /// </summary>
    [SerializeField, Tooltip("射出するオブジェクトをここに割り当てる")]
    private GameObject ThrowingObject;

    /// <summary>
    /// 標的のオブジェクト
    /// </summary>
    [SerializeField, Tooltip("標的のオブジェクトをここに割り当てる")]
    private GameObject TargetObject;

    /// <summary>
    /// 射出角度
    /// </summary>
    [SerializeField,Tooltip("射出する角度")]
    private float ThrowingAngle = 50.0f;

    private GameObject StartBall;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip clip; // 投げた時の音   

    private void Start()
    {
        StartBall = GameObject.Find("Floor");
    }

    private void Update()
    {
        if (StartBall.GetComponent<Floor>().preparation == true)
        {
            Key();
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(Power + "放した");
                soundManager.Play(clip);
                TargetDistance();
                ThrowingBall();
                Power = 0;
                StartBall.GetComponent<Floor>().preparation = false;
                //if (powercount10 == false)

                //powercount10 = true;
                ////ThrowingPower.Destroy(this);
            }
        }
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
                    if (Power >= 50)
                    {
                        Power += 0.6f;
                    }
                    else
                    {
                        Power += 0.1f;
                        Debug.Log(Power + "増えてる");
                    }

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
                if (Power >= 50)
                {
                    Power -= 0.6f;
                }
                else
                {
                    Power -= 0.1f;
                    Debug.Log(Power + "減ってる");
                }
                if ((int)Power == MinPower)
                {
                    powercount = false;
                }
            }
        }
    }

    public void TargetDistance()
    {
        TargetObject.transform.position = new Vector3(0, 0, Power);
    }


    /// <summary>
    /// ボールを射出する
    /// </summary>
    private void ThrowingBall()
    {
        if (ThrowingObject != null && TargetObject != null)
        {
            // Ballオブジェクトの生成
            GameObject ball = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

            // 標的の座標
            Vector3 targetPosition = TargetObject.transform.position;

            // 射出角度
            float angle = ThrowingAngle;

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // 射出
            Rigidbody rid = ball.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }
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
