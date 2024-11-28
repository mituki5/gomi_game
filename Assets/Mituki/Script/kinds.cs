using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class kinds : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject nextObject;
    public List<string> _name = new List<string>();
    public int index;
    private int nextIndex;
    [SerializeField] private GameObject trashBox;
    private enum TrashType
    {
        plasticbottle,
        bottle,
        cap,
        Trash,
        plastic,
    }
    [SerializeField] private List<GameObject> trashPrefabs = new List<GameObject>();
    private ThrowingPower firstThrowingpower;
    [SerializeField] public float weight;
    public int totalnumber = 30;
    public int number;
    public bool separation = true;

    public bool isJudging = true;

    private GameObject TrashImage;
    private GameObject PlasticImage;
    private GameObject BottleImage;

    public void Start()
    {
        // ������: �ŏ��̃S�~�𐶐�
        int tmpIndex = Random.Range(0, _name.Count);
        firstObject = Instantiate(trashPrefabs[tmpIndex], this.transform);
        firstThrowingpower = firstObject.GetComponent<ThrowingPower>();
        index = tmpIndex;
        firstThrowingpower.SetScript(trashBox, this, true);

        Kinds();

        // ���̃S�~�𐶐�
        tmpIndex = Random.Range(0, _name.Count);
        nextObject = Instantiate(trashPrefabs[tmpIndex], this.transform);
        nextIndex = tmpIndex;

        //// UI ������
        //TrashImage = GameObject.Find("TrashImage");
        //TrashImage.SetActive(false);
        //PlasticImage = GameObject.Find("PlasticImage");
        //PlasticImage.SetActive(false);
        //BottleImage = GameObject.Find("BottleImage");
        //BottleImage.SetActive(false);
    }

    private void Update()
    {
        // �S�~�����n���Ă���΁A�V�����S�~�𐶐�
        if (firstThrowingpower.iscanShoot == false)
        {
            FirstInstantiateTrash(); //firstObject���X�V
            SecondInstantiateTrash(); //���̃S�~�𐶐�
            Kinds(); // ��ނ��X�V
            firstThrowingpower.iscanShoot = true;
        }

        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast�ŃI�u�W�F�N�g�����o
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                Debug.Log($"Raycast�����o: {hitObject.name}");

                // ����Ώۂ�`plasticbottle`�̏ꍇ�̂ݏ���
                if (_name.Contains(hitObject.name) && hitObject.name == "plasticbottle")
                {
                    Debug.Log("���������s");
                    Separation(hitObject);
                }
            }
        }

        //���v���itotalnumber�j��0�ɒB�����ꍇ�A���Z�b�g���ĐV��������ݒ�
        if (totalnumber <= 0){
            ResetTrashCounts();
        }
    }

    private void FirstInstantiateTrash()
    {
        // ���̃S�~�����݂̃S�~�Ɉړ�
        firstObject.name = nextObject.name;
        firstObject = nextObject;
        firstThrowingpower = firstObject.GetComponent<ThrowingPower>();
        firstThrowingpower.SetScript(trashBox, this, true);
        index = nextIndex;

        // �Â��q�I�u�W�F�N�g���폜
        if (firstObject.transform.childCount > 0)
        {
            Destroy(firstObject.transform.GetChild(0).gameObject);
        }
    }

    private void SecondInstantiateTrash()
    {
        // �V�����S�~�𐶐�
        nextIndex = Random.Range(0, _name.Count);
        nextObject.name = _name[nextIndex];
        nextObject = Instantiate(trashPrefabs[nextIndex], transform);
    }

    public void Kinds()
    {
        // �S�~�̎�ނɉ����Đݒ�
        switch (_name[index])
        {
            case "plasticbottle":
                weight = 3.0f;
                number = 6;
                //nextIndex = Random.Range(0, number);
                Count();
                break;
            case "bottle":
                weight = 3.0f;
                number = 6;
                //nextIndex = Random.Range(number, 12);
                Count();
                break;
            case "cap":
                weight = 1.0f;
                number = 6;
                //nextIndex = Random.Range(number, 18);
                Count();
                break;
            case "Trash":
                weight = 1.0f;
                number = 6;
                //nextIndex = Random.Range(number, 24);
                Count();
                break;
            case "plastic":
                weight = 5.0f;
                number = 6;
                //nextIndex = Random.Range(number, totalnumber);
                Count();
                break;
            default:
                weight = 1.0f;
                break;
        }
    }

    /// <summary>
    /// �S�~�𕪉�����֐�
    /// </summary>
    private void Separation(GameObject targetObject)
    {
        Debug.Log("�������������s");

        if (targetObject.transform.childCount > 0)
        {
            Destroy(targetObject.transform.GetChild(0).gameObject);
        }

        // ������̃S�~�𐶐�
        firstObject = Instantiate(trashPrefabs[(int)TrashType.bottle], firstObject.transform);
        //GameObject bottle = Instantiate(trashPrefabs[(int)TrashType.bottle], targetObject.transform);
        //bottle.transform.localPosition = Vector3.zero;

        nextObject = Instantiate(trashPrefabs[(int)TrashType.cap], nextObject.transform);
        //GameObject cap = Instantiate(trashPrefabs[(int)TrashType.cap], targetObject.transform);
        //cap.transform.localPosition = new Vector3(0, -0.5f, 0); // �L���b�v���������ɔz�u

        Debug.Log("��������: �{�g���ƃL���b�v�𐶐�");
    }

    /// <summary>
    /// �����Ǘ�����֐�
    /// </summary>
    public void Count()
    {
        if (nextObject.name == _name[index])
        {
            totalnumber--;
            number--;
        }
    }

    private void ResetTrashCounts()
    {
        Debug.Log("�����v����0�ɒB�������߁A�J�E���g�����Z�b�g");

        totalnumber = 30; // �V���������v����ݒ�

        // �e�S�~�̌��������_���ɐݒ� (��Ƃ��čő�10��ݒ�\�ɂ���)
        int maxPerType = 10;
        for (int i = 0; i < _name.Count; i++)
        {
            int count = Random.Range(1, maxPerType + 1);
            Debug.Log($"�S�~���: {_name[i]}, �ݒ��: {count}");
            // �K�v�ɉ����Ċe��ނ̃S�~�����Ǘ����郊�X�g�⎫����p��
        }
    }
}