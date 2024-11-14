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
    private int nextIndex;
    [SerializeField] private GameObject trashBox;
    private enum TrashType
    {
        //plasticbottle,
        //bottle,
        //cap,
        //Trash,
        //plastic,
        trash,
        trash2,
            trash3,
    }
    [SerializeField] List<GameObject> trashPrefabs = new List<GameObject>();
    private ThrowingPower firstThrowingpower;
    [SerializeField] public float weight;
    public int totalnumber = 30;
    public int number;

    public void Start()
    {
        int tmpIndex = Random.Range(0, _name.Count);
        firstObject = Instantiate(trashPrefabs[tmpIndex], this.transform);
        firstThrowingpower = firstObject.GetComponent<ThrowingPower>();
        index = tmpIndex;
        firstThrowingpower.SetScript(trashBox, this, true);
        Kinds();
        tmpIndex = Random.Range(0, _name.Count);
        nextObject = Instantiate(trashPrefabs[tmpIndex], nextObject.transform);
        nextIndex = tmpIndex;
    }

    private void Update()
    {
        if (firstThrowingpower.landing == false)
            {
                FirstInstantiateTrash();
                //SecondInstantiateTrash();
                Kinds();
                firstThrowingpower.landing = true;
                firstThrowingpower.shot = true;
            }
    }

    private void FirstInstantiateTrash()
    {
        SecondInstantiateTrash();
        firstObject.name = nextObject.name;
        firstObject = nextObject;
        firstThrowingpower = firstObject.GetComponent<ThrowingPower>();
        firstThrowingpower.SetScript(trashBox, this, true);
        index = nextIndex;
    }

    private void SecondInstantiateTrash()
    {
        nextIndex = (int)Random.Range(0.0f, _name.Count);
        nextObject.name = _name[index];
        nextObject = Instantiate(trashPrefabs[index], transform);
    }
    public void Kinds()
    {
        switch (_name[index])
        {
            //�y�b�g�{�g���̏ꍇ�̂ݕ���
            case "plasticbottle":
                weight = 3.0f;
                number = 6;
                nextIndex = Random.Range(0, number);
                Count();
                break;
            case "bottle":
                weight = 3.0f;
                number = 6;
                nextIndex = Random.Range(number, 12);
                Count();
                break;
            case "cap":
                weight = 1.0f;
                number = 6;
                nextIndex = Random.Range(number, 18);
                Count();
                break;
            case "Trash":
                weight = 1.0f;
                number = 6;
                nextIndex = Random.Range(number, 24);
                Count();
                break;
            case "plastic":
                weight = 5.0f;
                number = 6;
                nextIndex = Random.Range(number, totalnumber);
                Count();
                break;
            default:
                weight = 1.0f;
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
        Destroy(nextObject);
        //������ꏊ�ɕ�������firstObject��u��
        Instantiate(trashPrefabs[(int)TrashType.trash2], firstObject.transform);
        //���̂Ƃ���
        Instantiate(trashPrefabs[(int)TrashType.trash2], nextObject.transform);
    }

    /// <summary>
    /// �N���b�N�ɂ�镪��������֐�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            if (_name[index] == "cap")
            {
                Debug.Log("����");
                Separation();
            }
        }

    }

    public void Count()
    {
        if(nextObject.name == _name[index])
        {
            totalnumber--;
            number--;
        }
    }
}
