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
    //[SerializeField] public string _name;
    public List<string> _name = new List<string>();
    public int index;

    //��������邲��
    [SerializeField] public GameObject Plastic_bottle;
    [SerializeField] public GameObject bottelObject;
    [SerializeField] public GameObject capObject;
    [SerializeField] public GameObject trash_paper;
    [SerializeField] public GameObject lunch_box;


    [SerializeField] public float weight;

    public void Start()
    {
        Instantiate(firstObject);

        _name.Add("plastic_bottle");
        _name.Add("bottle");
        _name.Add("cap");
        _name.Add("trash_paper");
        _name.Add("lunch_box");
        //Vector3 firstpos = firstObject.transform.position;
        //Vector3 nextpos = nextObject.transform.position;
        
    }

    private void Update()
    {
        Throwingpoewr throwingpoewrScript = GetComponent<Throwingpoewr>();
        if (throwingpoewrScript.landing == false)
        {
            index = (int)Random.Range(0.0f, _name.Count);
            //��������̖̂��O���擾
            Kinds();
        }
    }

    public void Kinds()
    {
        
        switch (_name[index])
            {
                //�y�b�g�{�g���̏ꍇ�̂ݕ���
                case "plastic_bottle":
                    weight = 3.0f;
                break;
                case "bottle":
                    weight = 3.0f;
                break;
                case "cap":
                    weight = 1.0f;
                break;
                case "trash_paper":
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
        Instantiate(bottelObject,firstObject.transform);
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
            if (_name[index] == "Plastic_bottle")
            {
                Debug.Log("����");
                Separation();
            }
        }

    }
}
