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
        //Plastic_bottle,
        Bottle,//bottle
        Cap,//cap
        Trash,//paper
        //LunchBox
    }
    private enum Disassembled
    {
        BottelObject,
        CapObject,
    }
    [SerializeField] List<GameObject> trashPrefabs = new List<GameObject>();
    //��������邲��
    //[SerializeField] public GameObject Plastic_bottle;
    //[SerializeField] public GameObject bottelObject;
    //[SerializeField] public GameObject capObject;
    //[SerializeField] public GameObject trash_paper;
    //[SerializeField] public GameObject lunch_box;

    private ThrowingPower firstThrowingpower;
    [SerializeField] public float weight;

    private GameObject time;

    public void Start()
    {
        //_name.Add("plastic_bottle");
        //_name.Add("bottle");
        //_name.Add("cap");
        //_name.Add("trash_paper");
        //_name.Add("lunch_box");
        //Vector3 firstpos = firstObject.transform.position;
        //Vector3 nextpos = nextObject.transform.position;

        int tmpIndex = Random.Range(0, _name.Count);
        firstObject = Instantiate(trashPrefabs[tmpIndex], this.transform);
        firstThrowingpower = firstObject.GetComponent<ThrowingPower>();
        index = tmpIndex;
        firstThrowingpower.SetScript(trashBox, this, true);
        Kinds();
        tmpIndex = Random.Range(0, _name.Count);
        //next�̃I�u�W�F�N�g���J�n���㓯���ꏊ�ɐ�������Ă��遫
        nextObject = Instantiate(trashPrefabs[tmpIndex], nextObject.transform);
        nextIndex = tmpIndex;

        time = GameObject.Find("TimeObject");
    }

    private void Update()
    {
        if (time.GetComponent<TimeCounter>().start == true)
        {
            if (firstThrowingpower.landing == false)
            {
                FirstInstantiateTrash();
                //SecondInstantiateTrash();
                Kinds();
                firstThrowingpower.landing = true;
                firstThrowingpower.shot = true;
            }

            //if(firstObject.transform.position.y < -5 || firstObject.transform.position.y > 10.0f)
            //{
            //    Destroy(firstObject);
            //    Debug.Log(firstObject.name);
            //}
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
            case "plastic_bottle":
                weight = 3.0f;
                break;
            case "bottle":
                weight = 3.0f;
                break;
            case "cap":
                weight = 1.0f;
                break;
            case "Trash":
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
        Destroy(nextObject);
        //������ꏊ�ɕ�������firstObject��u��
        Instantiate(trashPrefabs[(int)Disassembled.BottelObject], firstObject.transform);
        //���̂Ƃ���
        Instantiate(trashPrefabs[(int)Disassembled.CapObject], nextObject.transform);
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
