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
    private ThrowingPower throwingPower;
    private enum TrashType
    {
        plasticbottle,
        bottle,
        cap,
        Trash,
        plastic,
    }
    [SerializeField] private List<GameObject> trashPrefabs = new List<GameObject>();

    [SerializeField] public float weight;
    public int totalnumber = 10;
    //public bool separation = true;

    public bool isGround = true;
    public bool isProcessing = true;

    private Dictionary<string, int> trashCounts = new Dictionary<string, int>();

    private GameObject TrashImage;
    private GameObject PlasticImage;
    private GameObject BottleImage;

    public void Start()
    {
        // ゴミの種類ごとの初期値を設定 (指定された個数)
        trashCounts["plasticbottle(Clone)"] = 2;
        trashCounts["bottle(Clone)"] = 1;
        trashCounts["cap(Clone)"] = 1;
        trashCounts["Trash(Clone)"] = 3;
        trashCounts["plastic(Clone)"] = 3;

        // 初期化: 最初のゴミを生成
        SecondInstantiateTrash();
        FirstInstantiateTrash();
        SecondInstantiateTrash();
        Kinds();
        isGround = true;

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
        if (isGround == false && isProcessing == true)
        {
            //Destroy(now);
            FirstInstantiateTrash(); //firstObjectを更新
            SecondInstantiateTrash(); //次のゴミを生成
            Kinds(); // 種類を更新
            isGround = true;

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
                DecreaseTrashCount(hitObject.name);

                // 分解対象が`plasticbottle`の場合のみ処理
                //ゴミが投げられた場合、その種類に応じてカウントを減らす
                if (hitObject.name == "plasticbottle(Clone)")
                { 
                    Debug.Log("分解を実行");
                    Separation(hitObject);
                    // 分解対象がそのゴミの名前に一致する場合のみ処理
                    DecreaseTrashCount(hitObject.name);
                    isProcessing = true;
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
        //Destroy(now);
        now = next;
        now.transform.parent = this.transform; // 親を変更
        now.transform.position = this.transform.position; // 座標をコピー
        now.transform.rotation = this.transform.rotation; // 回転をコピー
        var firstThrowingPower = now.GetComponent<ThrowingPower>();
        firstThrowingPower.SetScript(trashBox, this, true);
        index = nextIndex;
    }

    private void SecondInstantiateTrash()
    {
        // 新しいゴミを生成
        var tmpIndex = Random.Range(0, _name.Count);
        next = Instantiate(trashPrefabs[tmpIndex], nextObject.transform);
        nextIndex = tmpIndex;
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
                weight = 2.0f;
                break;
            case "Trash":
                weight = 2.0f;
                break;
            case "plastic":
                weight = 5.0f;
                break;
            default:
                weight = 2.0f;
                break;
        }
    }

    /// <summary>
    /// ゴミを分解する関数
    /// </summary>
    private void Separation(GameObject targetObject)
    {
        Debug.Log("分解処理を実行");
        isProcessing = false;

        if (targetObject.transform.childCount > 0)
        {
            Destroy(targetObject.transform.GetChild(0).gameObject);
        }
        Destroy(now);
        Destroy(next);
        // 分解後のゴミを生成
        now = Instantiate(trashPrefabs[(int)TrashType.bottle], this.transform);

        next = Instantiate(trashPrefabs[(int)TrashType.cap], next.transform);

        Debug.Log("分解完了: ボトルとキャップを生成");
    }

    /// <summary>
    /// ゴミの種類を判定して数を減らす処理
    /// </summary>
    private void DecreaseTrashCount(string trashName)
    {
        Debug.Log("出来てる") ;
        // ゴミの種類ごとに個数を減らす
        //SecondInstantiateTrash();
        Debug.Log($"trashName: {trashName}, now.name: {now.name}");
        if (trashName == now.name)
        {
            trashCounts[trashName]--;
            totalnumber--; // 合計数を減らす
            //SecondInstantiateTrash();
            Debug.Log($"{trashName}の数を1減らしました。残り数: {trashCounts[trashName]}");

            // ゴミが分解された場合
            if (trashName == "plasticbottle(Clone)")
            {
                // 分解後、bottle と cap を増やす
                trashCounts["bottle(Clone)"]++;
                trashCounts["cap(Clone)"]++;
                Debug.Log("plasticbottle を分解して bottle と cap を増やしました");
            }

            if (trashCounts[trashName] <= 0)
            {
                Debug.Log($"{trashName}はもう残っていません");
                var _name = new List<string>();
                _name.Remove(now.name);
            }
        }
        else
        {
            Debug.Log("名前違う");
            return;
        }
    }

    private void ResetTrashCounts()
    {
        Debug.Log("総合計数が0に達したため、カウントをリセット");

        totalnumber = 10; // 合計数は10に設定

        // 各ゴミの個数をリセット (指定された個数)
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


        // 各ゴミの個数をデバッグログに出力
        foreach (var entry in trashCounts)
        {
            Debug.Log($"ゴミ種類: {entry.Key}, 設定個数: {entry.Value}");
        }
    }
}
