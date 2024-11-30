using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class kinds : MonoBehaviour
{
    public GameObject nextObject;
    public GameObject now;
    public GameObject next;

    public List<string> _name = new List<string>();
    public int index;
    public int nextIndex;
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
    //private KindsSub kindsSub;

    [SerializeField] public float weight;
    public int totalnumber = 10;
    public bool separation = true;

    public bool isJudging = true;
    public bool isGround = true;
    public bool isProcessing = true;

    private Dictionary<string, int> trashCounts = new Dictionary<string, int>();

    private GameObject TrashImage;
    private GameObject PlasticImage;
    private GameObject BottleImage;

    public void Start()
    {
        // �S�~�̎�ނ��Ƃ̏����l��ݒ� (�w�肳�ꂽ��)
        trashCounts["plasticbottle(Clone)"] = 2;
        trashCounts["bottle(Clone)"] = 1;
        trashCounts["cap(Clone)"] = 1;
        trashCounts["Trash(Clone)"] = 3;
        trashCounts["plastic(Clone)"] = 3;

        // ������: �ŏ��̃S�~�𐶐�
        SecondInstantiateTrash();
        FirstInstantiateTrash();
        SecondInstantiateTrash();

        //Kinds();

        //// UI ������
        TrashImage = GameObject.Find("TrashImage");
        TrashImage.SetActive(false);
        PlasticImage = GameObject.Find("PlasticImage");
        PlasticImage.SetActive(false);
        BottleImage = GameObject.Find("BottleImage");
        BottleImage.SetActive(false);
    }

    private void Update()
    {
        // �S�~�����n���Ă���΁A�V�����S�~�𐶐�
        if (isGround == false)
        //if(throwingPower.iscanShoot == false)
        {
            FirstInstantiateTrash(); //firstObject���X�V
            SecondInstantiateTrash(); //���̃S�~�𐶐�
            //Kinds(); // ��ނ��X�V
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
                DecreaseTrashCount(hitObject.name);

                // ����Ώۂ�`plasticbottle`�̏ꍇ�̂ݏ���
                //�S�~��������ꂽ�ꍇ�A���̎�ނɉ����ăJ�E���g�����炷
                if (hitObject.name == "plasticbottle(Clone)")
                { 
                    //isProcessing = false;
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
        //Destroy(now);
        now = next;
        now.transform.parent = this.transform; // �e��ύX
        now.transform.position = this.transform.position; // ���W���R�s�[
        now.transform.rotation = this.transform.rotation; // ��]���R�s�[
        var firstThrowingPower = now.GetComponent<ThrowingPower>();
        firstThrowingPower.SetScript(trashBox, this, true);
        index = nextIndex;

        // ThrowingPower �̐ݒ�
        var throwingPower = now.GetComponent<ThrowingPower>();
        if (throwingPower != null)
        {
            throwingPower.SetScript(trashBox, this, true); // kinds ���Z�b�g
            isGround = true;
        }
        else
        {
            Debug.LogError("ThrowingPower �R���|�[�l���g��������܂���");
        }
    }

    private void SecondInstantiateTrash()
    {
        //Destroy(now);

        // �V�����S�~�𐶐�
        var tmpIndex = Random.Range(0, _name.Count);
        next = Instantiate(trashPrefabs[tmpIndex], nextObject.transform);
        nextIndex = tmpIndex;
    }

    //public void Kinds()
    //{
    //    // �S�~�̎�ނɉ����Đݒ�
    //    switch (_name[index])
    //    {
    //        case "plasticbottle":
    //            weight = 3.0f;
    //            break;
    //        case "bottle":
    //            weight = 3.0f;
    //            break;
    //        case "cap":
    //            weight = 2.0f;
    //            break;
    //        case "Trash":
    //            weight = 2.0f;
    //            break;
    //        case "plastic":
    //            weight = 5.0f;
    //            break;
    //        default:
    //            weight = 2.0f;
    //            break;
    //    }
    //}

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
        Destroy(now);
        Destroy(next);
        // ������̃S�~�𐶐�
        now = Instantiate(trashPrefabs[(int)TrashType.bottle], this.transform);

        next = Instantiate(trashPrefabs[(int)TrashType.cap], next.transform);

        Debug.Log("��������: �{�g���ƃL���b�v�𐶐�");
        isProcessing = true;
    }

    /// <summary>
    /// �S�~�̎�ނ𔻒肵�Đ������炷����
    /// </summary>
    private void DecreaseTrashCount(string trashName)
    {
        Debug.Log("�o���Ă�") ;
        // �S�~�̎�ނ��ƂɌ������炷
        //SecondInstantiateTrash();
        Debug.Log($"trashName: {trashName}, now.name: {now.name}");
        if (trashName == now.name)
        {
            trashCounts[trashName]--;
            totalnumber--; // ���v�������炷
            //SecondInstantiateTrash();
            Debug.Log($"{trashName}�̐���1���炵�܂����B�c�萔: {trashCounts[trashName]}");

            // �S�~���������ꂽ�ꍇ
            if (trashName == "plasticbottle(Clone)")
            {
                // ������Abottle �� cap �𑝂₷
                trashCounts["bottle(Clone)"]++;
                trashCounts["cap(Clone)"]++;
                Debug.Log("plasticbottle �𕪉����� bottle �� cap �𑝂₵�܂���");
            }

            if (trashCounts[trashName] <= 0)
            {
                Debug.Log($"{trashName}�͂����c���Ă��܂���");
                var _name = new List<string>();
                _name.Remove(now.name);
            }
        }
        else
        {
            Debug.Log("���O�Ⴄ");
            return;
        }
    }

    private void ResetTrashCounts()
    {
        Debug.Log("�����v����0�ɒB�������߁A�J�E���g�����Z�b�g");

        totalnumber = 10; // ���v����10�ɐݒ�

        // �e�S�~�̌������Z�b�g (�w�肳�ꂽ��)
        trashCounts["plasticbottle(Clone)"] = 2;
        trashCounts["bottle(Clone)"] = 1;
        trashCounts["cap(Clone)"] = 1;
        trashCounts["Trash(Clone)"] = 3;
        trashCounts["plastic(Clone)"] = 3;

        var _name = new List<string>();
        _name.Add("plasticbottle");
        _name.Add("bottle");
        _name.Add("cap");
        _name.Add("Trash");
        _name.Add("plastic");


        // �e�S�~�̌����f�o�b�O���O�ɏo��
        foreach (var entry in trashCounts)
        {
            Debug.Log($"�S�~���: {entry.Key}, �ݒ��: {entry.Value}");
        }
    }
}
