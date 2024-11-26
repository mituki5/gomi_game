using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class kinds : MonoBehaviour//, IPointerClickHandler
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

    private GameObject TrashImage;
    private GameObject PlasticImage;
    private GameObject BottleImage;

    public void Start()
    {
        // 初期化: 最初のゴミを生成
        int tmpIndex = Random.Range(0, _name.Count);
        firstObject = Instantiate(trashPrefabs[tmpIndex], this.transform);
        firstThrowingpower = firstObject.GetComponent<ThrowingPower>();
        index = tmpIndex;
        firstThrowingpower.SetScript(trashBox, this, true);

        Kinds();

        // 次のゴミを生成
        tmpIndex = Random.Range(0, _name.Count);
        nextObject = Instantiate(trashPrefabs[tmpIndex], this.transform);
        nextIndex = tmpIndex;

        //// UI 初期化
        //TrashImage = GameObject.Find("TrashImage");
        //TrashImage.SetActive(false);
        //PlasticImage = GameObject.Find("PlasticImage");
        //PlasticImage.SetActive(false);
        //BottleImage = GameObject.Find("BottleImage");
        //BottleImage.SetActive(false);
    }

    private void Update()
    {
        // ゴミが着地していれば、新しいゴミを生成
        if (firstThrowingpower.canShoot == true)
        {
            FirstInstantiateTrash(); // `firstObject`を更新
            SecondInstantiateTrash(); // 次のゴミを生成
            Kinds(); // 種類を更新
            firstThrowingpower.canShoot = false;
        }

        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycastでオブジェクトを検出
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                Debug.Log($"Raycastが検出: {hitObject.name}");

                // 分解対象が`plasticbottle`の場合のみ処理
                if (_name.Contains(hitObject.name) && hitObject.name == "plasticbottle")
                {
                    Debug.Log("分解を実行");
                    Separation(hitObject);
                }
            }
        }

        //合計数（totalnumber）が0に達した場合、リセットして新しい個数を設定
        if (totalnumber <= 0){
            ResetTrashCounts();
        }
    }

    private void FirstInstantiateTrash()
    {
        // 次のゴミを現在のゴミに移動
        firstObject.name = nextObject.name;
        firstObject = nextObject;
        firstThrowingpower = firstObject.GetComponent<ThrowingPower>();
        firstThrowingpower.SetScript(trashBox, this, true);
        index = nextIndex;

        // 古い子オブジェクトを削除
        if (firstObject.transform.childCount > 0)
        {
            Destroy(firstObject.transform.GetChild(0).gameObject);
        }
    }

    private void SecondInstantiateTrash()
    {
        // 新しいゴミを生成
        nextIndex = Random.Range(0, _name.Count);
        nextObject = Instantiate(trashPrefabs[nextIndex], transform);
        nextObject.name = _name[nextIndex];
    }

    public void Kinds()
    {
        // ゴミの種類に応じて設定
        switch (_name[index])
        {
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
    /// ゴミを分解する関数
    /// </summary>
    private void Separation(GameObject targetObject)
    {
        Debug.Log("分解処理を実行");

        if (targetObject.transform.childCount > 0)
        {
            Destroy(targetObject.transform.GetChild(0).gameObject);
        }

        // 分解後のゴミを生成
        GameObject bottle = Instantiate(trashPrefabs[(int)TrashType.bottle], targetObject.transform);
        bottle.transform.localPosition = Vector3.zero;

        GameObject cap = Instantiate(trashPrefabs[(int)TrashType.cap], targetObject.transform);
        cap.transform.localPosition = new Vector3(0, -0.5f, 0); // キャップを少し下に配置

        Debug.Log("分解完了: ボトルとキャップを生成");
    }

    /// <summary>
    /// クリックによる分解処理
    /// </summary>
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.pointerId == -1) // 左クリック
    //    {
    //        if (_name[index] == "plasticbottle")
    //        {
    //            Debug.Log("クリックによる分解");
    //            Separation();
    //        }
    //    }
    //}

    /// <summary>
    /// 数を管理する関数
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
        Debug.Log("総合計数が0に達したため、カウントをリセット");

        totalnumber = 30; // 新しい総合計数を設定

        // 各ゴミの個数をランダムに設定 (例として最大10個を設定可能にする)
        int maxPerType = 10;
        for (int i = 0; i < _name.Count; i++)
        {
            int count = Random.Range(1, maxPerType + 1);
            Debug.Log($"ゴミ種類: {_name[i]}, 設定個数: {count}");
            // 必要に応じて各種類のゴミ個数を管理するリストや辞書を用意
        }
    }
}