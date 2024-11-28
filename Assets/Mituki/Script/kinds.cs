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
    public int totalnumber = 10;
    public bool separation = true;

    public bool isJudging = true;

    private Dictionary<string, int> trashCounts = new Dictionary<string, int>();

    private GameObject TrashImage;
    private GameObject PlasticImage;
    private GameObject BottleImage;

    public void Start()
    {
        // �S�~�̎�ނ��Ƃ̏����l��ݒ� (�w�肳�ꂽ��)
        trashCounts["plasticbottle"] = 2;
        trashCounts["bottle"] = 1;
        trashCounts["cap"] = 1;
        trashCounts["Trash"] = 3;
        trashCounts["plastic"] = 3;

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

            // Raycast������ (�f�o�b�O�p)
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1f);

            // Raycast�ŃI�u�W�F�N�g�����o
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                Debug.Log($"Raycast�����o: {hitObject.name}");

                // ����Ώۂ�`plasticbottle`�̏ꍇ�̂ݏ���
                //�S�~��������ꂽ�ꍇ�A���̎�ނɉ����ăJ�E���g�����炷
                //if (_name.Contains(hitObject.name) && hitObject.name == "plasticbottle")
                //if(hitObject.CompareTag("PlasticBottle"))
                if(_name.Contains(hitObject.name))
                {
                    Debug.Log("���������s");
                    Separation(hitObject);
                    // ����Ώۂ����̃S�~�̖��O�Ɉ�v����ꍇ�̂ݏ���
                    DecreaseTrashCount(hitObject.name);
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
        nextIndex = (int)Random.Range(0, _name.Count);
        nextObject.name = _name[index];
        nextObject = Instantiate(trashPrefabs[index], transform);
    }

    public void Kinds()
    {
        // �S�~�̎�ނɉ����Đݒ�
        switch (_name[index])
        {
            case "plasticbottle":
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
            case "plastic":
                weight = 5.0f;
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
    /// �S�~�̎�ނ𔻒肵�Đ������炷����
    /// </summary>
    private void DecreaseTrashCount(string trashName)
    {
        // �S�~�̎�ނ��ƂɌ������炷
        if (trashCounts.ContainsKey(trashName))
        {
            trashCounts[trashName]--;
            totalnumber--; // ���v�������炷
            Debug.Log($"{trashName}�̐���1���炵�܂����B�c�萔: {trashCounts[trashName]}");

            // �S�~���������ꂽ�ꍇ
            if (trashName == "plasticbottle")
            {
                // ������Abottle �� cap �𑝂₷
                trashCounts["bottle"]++;
                trashCounts["cap"]++;
                Debug.Log("plasticbottle �𕪉����� bottle �� cap �𑝂₵�܂���");
            }

            if (trashCounts[trashName] <= 0)
            {
                Debug.Log($"{trashName}�͂����c���Ă��܂���");
            }
        }
    }

    private void ResetTrashCounts()
    {
        Debug.Log("�����v����0�ɒB�������߁A�J�E���g�����Z�b�g");

        totalnumber = 10; // ���v����10�ɐݒ�

        // �e�S�~�̌������Z�b�g (�w�肳�ꂽ��)
        trashCounts["plasticbottle"] = 2;
        trashCounts["bottle"] = 1;
        trashCounts["cap"] = 1;
        trashCounts["Trash"] = 3;
        trashCounts["plastic"] = 3;

        // �e�S�~�̌����f�o�b�O���O�ɏo��
        foreach (var entry in trashCounts)
        {
            Debug.Log($"�S�~���: {entry.Key}, �ݒ��: {entry.Value}");
        }
    }
}
