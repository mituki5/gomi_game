using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//��ނƕ���
public class kinds : MonoBehaviour, IPointerClickHandler
{
    public GameObject firstObject;
    public GameObject nextObject;
    [SerializeField]�@public string _name;

    public GameObject bottelObject;
    public GameObject capObject;
    [SerializeField] public float weight;

    public void Start()
    {
        Vector3 firstpos = transform.position;
        Vector3 nextpos = transform.position;
    }

    private void Update()
    {
        //��������̖̂��O���擾
        _name = firstObject.name;
        Kinds();
    }

    public void Kinds()
    {     
            switch (_name)
            {
                //�y�b�g�{�g���̏ꍇ�̂ݕ���
                case "Plastic_bottle":
                    weight = 3.0f;
                    break;
                case "bottle":
                    weight = 3.0f;
                    break;
                case "cap":
                    weight = 1.0f;
                    break;
                case "Trash_paper":
                    weight = 1.0f;
                    break;
                case "lunch_box":
                    weight = 5.0f;
                    break;
            }    
    }

    /// <summary>
    /// ��������֐�
    /// </summary>
    public void Separation()
    {
        //����O�̃y�b�g�{�g��������
        Destroy(firstObject);
        //������ꏊ�ɕ�������firstObject��u��
        Instantiate(bottelObject, firstObject.transform);
        //���̂Ƃ���

        Instantiate(capObject, nextObject.transform);
    }

    /// <summary>
    /// �N���b�N�ɂ�镪��������֐�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            //if (_name == "Plastic_bottle")
            //{
                Debug.Log("����");
                Separation();
            //}
            //else
            //{
                //�ʂ̂Ƃ��ꍇ
            //}
        }

    }
}
