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
    [SerializeField]　public string _name;

    public GameObject bottelObject;
    public GameObject capObject;
    [SerializeField] public float weight;

    public void Start()
    {
        Vector3 firstpos = transform.position;
        Vector3 nextpos = transform.position;
    }

    private void Update()
    {
        //投げるものの名前を取得
        _name = firstObject.name;
        Kinds();
    }

    public void Kinds()
    {     
            switch (_name)
            {
                //ペットボトルの場合のみ分解
                case "Plastic_bottle":
                    weight = 3.0f;
                    break;
                case "bottle":
                    weight = 3.0f;
                    break;
                case "cap":
                    weight = 1.0f;
                    break;
                case "Trash_paper":
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
        Instantiate(bottelObject, firstObject.transform);
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
            //if (_name == "Plastic_bottle")
            //{
                Debug.Log("分解");
                Separation();
            //}
            //else
            //{
                //別のとこ場合
            //}
        }

    }
}
