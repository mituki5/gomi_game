using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//種類と分解
public class kinds : MonoBehaviour, IPointerClickHandler
{
    public GameObject firstObject;
    public GameObject nextObject;
    //[SerializeField] public string _name;
    public List<string> _name = new List<string>();
    public int index;

    //生成されるごみ
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
            //投げるものの名前を取得
            Kinds();
        }
    }

    public void Kinds()
    {
        
        switch (_name[index])
            {
                //ペットボトルの場合のみ分解
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
    /// 分解する関数
    /// </summary>
    public void Separation()
    {
        //分解前のペットボトルを消す
        Destroy(firstObject);
        //投げる場所に分解したfirstObjectを置く
        Instantiate(bottelObject,firstObject.transform);
        //次のところ
        Instantiate(capObject, nextObject.transform);
    }

    /// <summary>
    /// クリックによる分解をする関数
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            if (_name[index] == "Plastic_bottle")
            {
                Debug.Log("分解");
                Separation();
            }
        }

    }
}
