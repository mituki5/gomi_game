using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��ނƕ���
public class kinds : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject nextObject;
    [SerializeField]�@public string _name;

    public GameObject bottelObject;
    public GameObject capObject;
    [SerializeField] public float weight;

    private void Update()
    {
        //��������̖̂��O���擾
        _name = firstObject.name;
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
        Destroy(firstObject);
        Instantiate(bottelObject, firstObject.transform);
        Instantiate(capObject, nextObject.transform);
    }

    /// <summary>
    /// �N���b�N�ɂ�镪��������֐�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (firstObject.name == "Plastic_bottle")
        {
            Separation();
        }
        else
        {
            //�ʂ̂Ƃ��ꍇ
        }
    }
}
