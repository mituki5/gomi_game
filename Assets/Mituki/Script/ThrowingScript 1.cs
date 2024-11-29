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
    /// �ˏo����I�u�W�F�N�g
    /// </summary>
    [SerializeField, Tooltip("�ˏo����I�u�W�F�N�g�������Ɋ��蓖�Ă�")]
    private GameObject ThrowingObject;

    /// <summary>
    /// �W�I�̃I�u�W�F�N�g
    /// </summary>
    [SerializeField, Tooltip("�W�I�̃I�u�W�F�N�g�������Ɋ��蓖�Ă�")]
    private GameObject TargetObject;

    /// <summary>
    /// �ˏo�p�x
    /// </summary>
    [SerializeField,Tooltip("�ˏo����p�x")]
    private float ThrowingAngle = 50.0f;

    private GameObject StartBall;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip clip; // ���������̉�   

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
                Debug.Log(Power + "������");
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
                    if (Power >= 50)
                    {
                        Power += 0.6f;
                    }
                    else
                    {
                        Power += 0.1f;
                        Debug.Log(Power + "�����Ă�");
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
                    Debug.Log(Power + "�����Ă�");
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
    /// �{�[�����ˏo����
    /// </summary>
    private void ThrowingBall()
    {
        if (ThrowingObject != null && TargetObject != null)
        {
            // Ball�I�u�W�F�N�g�̐���
            GameObject ball = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

            // �W�I�̍��W
            Vector3 targetPosition = TargetObject.transform.position;

            // �ˏo�p�x
            float angle = ThrowingAngle;

            // �ˏo���x���Z�o
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            // �ˏo
            Rigidbody rid = ball.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }
        else
        {
            throw new System.Exception("�ˏo����I�u�W�F�N�g�܂��͕W�I�̃I�u�W�F�N�g�����ݒ�ł��B");
        }
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
