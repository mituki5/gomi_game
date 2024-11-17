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
        //if(time.GetComponent<TimeCounter>().start == true)
        {
            if (!this.canShot) return;
            Key();

            if (Input.GetMouseButtonUp(0))
            {
                if (powercount10 == false)
                    Debug.Log(Power + "������");
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
    }


    /// <summary>
    /// �����Ă����Power�����߂�֐��i�J��Ԃ��j
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
                    Debug.Log(Power + "�����Ă�");
                    if (Power == 10)
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
                Debug.Log(Power + "�����Ă�");
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
    /// ������֐�
    /// </summary>
    public void Gauge()
    {
            // �W�I�̍��W
            Vector3 targetPosition = targetobject.transform.position;
        //Debug.Log(targetPosition);

            // �ˏo�p�x
            float angle = Angle;

            // �ˏo���x���Z�o
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // �ˏo
          Debug.Log(velocity);
        Debug.Log(kindScript.weight);
          Rigidbody rb = GetComponent<Rigidbody>();
           rb.AddForce(velocity * rb.mass / kindScript.weight, ForceMode.Impulse);
        rb.useGravity = true;

    }

    /// <summary>
    /// �W�I�ɖ�������ˏo���x�̌v�Z
    /// </summary>
    /// <param name="pointA">�ˏo�J�n���W</param>
    /// <param name="pointB">�W�I�̍��W</param>
    /// <returns>�ˏo���x</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // �ˏo�p�����W�A���ɕϊ�
        float rad = angle * Mathf.PI / 180;

        // ���������̋���x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));



        // ���������̋���y
        float y = pointA.y - pointB.y;

        // �Ε����˂̌����������x�ɂ��ĉ���
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // �����𖞂����������Z�o�ł��Ȃ����Vector3.zero��Ԃ�
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
