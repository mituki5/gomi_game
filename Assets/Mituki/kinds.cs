using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class kinds : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject nextObject;
    public string _name;

    public GameObject bottelObject;
    public GameObject capObject;

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
                break;
            case "bottle":
                break;
            case "cap":
                break;
            case "Trash_paper":
                break;
            case "lunch_box":
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

        }
    }
}
