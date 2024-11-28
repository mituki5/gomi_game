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
        // ゴミの種類ごとの初期値を設定 (指定された個数)
        trashCounts["plasticbottle"] = 2;
        trashCounts["bottle"] = 1;
        trashCounts["cap"] = 1;
        trashCounts["Trash"] = 3;
        trashCounts["plastic"] = 3;

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
        if (firstThrowingpower.iscanShoot == false)
        {
            FirstInstantiateTrash(); //firstObjectを更新
            SecondInstantiateTrash(); //次のゴミを生成
            Kinds(); // 種類を更新
            firstThrowingpower.iscanShoot = true;
        }

        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycastを可視化 (デバッグ用)
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1f);

            // Raycastでオブジェクトを検出
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                Debug.Log($"Raycastが検出: {hitObject.name}");

                // 分解対象が`plasticbottle`の場合のみ処理
                //ゴミが投げられた場合、その種類に応じてカウントを減らす
                //if (_name.Contains(hitObject.name) && hitObject.name == "plasticbottle")
                //if(hitObject.CompareTag("PlasticBottle"))
                if(_name.Contains(hitObject.name))
                {
                    Debug.Log("分解を実行");
                    Separation(hitObject);
                    // 分解対象がそのゴミの名前に一致する場合のみ処理
                    DecreaseTrashCount(hitObject.name);
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
        nextIndex = (int)Random.Range(0, _name.Count);
        nextObject.name = _name[index];
        nextObject = Instantiate(trashPrefabs[index], transform);
    }

    public void Kinds()
    {
        // ゴミの種類に応じて設定
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
        firstObject = Instantiate(trashPrefabs[(int)TrashType.bottle], firstObject.transform);
        //GameObject bottle = Instantiate(trashPrefabs[(int)TrashType.bottle], targetObject.transform);
        //bottle.transform.localPosition = Vector3.zero;

        nextObject = Instantiate(trashPrefabs[(int)TrashType.cap], nextObject.transform);
        //GameObject cap = Instantiate(trashPrefabs[(int)TrashType.cap], targetObject.transform);
        //cap.transform.localPosition = new Vector3(0, -0.5f, 0); // キャップを少し下に配置

        Debug.Log("分解完了: ボトルとキャップを生成");
    }

    /// <summary>
    /// ゴミの種類を判定して数を減らす処理
    /// </summary>
    private void DecreaseTrashCount(string trashName)
    {
        // ゴミの種類ごとに個数を減らす
        if (trashCounts.ContainsKey(trashName))
        {
            trashCounts[trashName]--;
            totalnumber--; // 合計数を減らす
            Debug.Log($"{trashName}の数を1減らしました。残り数: {trashCounts[trashName]}");

            // ゴミが分解された場合
            if (trashName == "plasticbottle")
            {
                // 分解後、bottle と cap を増やす
                trashCounts["bottle"]++;
                trashCounts["cap"]++;
                Debug.Log("plasticbottle を分解して bottle と cap を増やしました");
            }

            if (trashCounts[trashName] <= 0)
            {
                Debug.Log($"{trashName}はもう残っていません");
            }
        }
    }

    private void ResetTrashCounts()
    {
        Debug.Log("総合計数が0に達したため、カウントをリセット");

        totalnumber = 10; // 合計数は10に設定

        // 各ゴミの個数をリセット (指定された個数)
        trashCounts["plasticbottle"] = 2;
        trashCounts["bottle"] = 1;
        trashCounts["cap"] = 1;
        trashCounts["Trash"] = 3;
        trashCounts["plastic"] = 3;

        // 各ゴミの個数をデバッグログに出力
        foreach (var entry in trashCounts)
        {
            Debug.Log($"ゴミ種類: {entry.Key}, 設定個数: {entry.Value}");
        }
    }
}
