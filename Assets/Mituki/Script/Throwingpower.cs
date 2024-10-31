using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
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
        Key();
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(Power + "������");
            //Throw();
            TargetDistance();
            Gauge();

            Power = MinPower;
            landing = false;
            shot = false;
        }
        
    }

    public void Key()
    {
        Debug.Log(powercount);
        if (Input.GetMouseButton(0))
        {
            if(Power == MaxPower)
            {
                if (Power > MaxPower)
                {
                    powercount = true;
                }
            }
            if(Power == MinPower)
            {
                if (Power > MinPower)
                {
                    powercount = false;
                }
            }

            if(powercount == false)
            {
                    Power += 0.1f;
                    Debug.Log(Power + "�����Ă�");
            }

            if(powercount == true){
                    Power -= 0.1f;
                    Debug.Log(Power + "�����Ă�");

            }
        }
    }

    public void TargetDistance()
    {
        targetobject.transform.position = new Vector3(0,0, Power);
        Debug.Log(Power+"aaaaaaaa");
    }

    /// <summary>
    /// ������֐�
    /// </summary>
    public void Throw()
    {
        //Debug.Log(kindScript.firstObject.name);
        //Debug.Log(kindScript.weight);
        //if (kindScript.firstObject.name == kindScript._name[kindScript.index])
        //{
           
        //}
        //�͂̕���
        //Trash_box = GameObject.Find("TrashBox");
        //Vector3 pos = Trash_box.transform.position * Power - Player.transform.position;
        //50�x
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


    public void Gauge()
    {
            // �W�I�̍��W
            Vector3 targetPosition = targetobject.transform.position;
        Debug.Log(targetPosition);

            // �ˏo�p�x
            float angle = Angle;

            // �ˏo���x���Z�o
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // �ˏo
            Rigidbody rb = GetComponent<Rigidbody>();
           rb.AddForce(velocity * rb.mass, ForceMode.Impulse);
        Debug.Log(velocity);
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
        //������poawer��������
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
