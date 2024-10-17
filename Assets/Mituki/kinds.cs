using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class kinds : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject nextObject;
    public string _name;

    public GameObject bottelObject;
    public GameObject capObject;

    private void Update()
    {
        //投げるものの名前を取得
        _name = firstObject.name;
    }

    public void Kinds()
    {
        switch (_name)
        {
            //ペットボトルの場合のみ分解
            case "Plastic_bottle":
                break;
            case "bottle":
                break;
            case "cap":
                break;
            case "Trash_paper":
                break;
            case "lunch_box":
                break;
        }
    }

    /// <summary>
    /// 分解する関数
    /// </summary>
    public void Separation()
    {
        Destroy(firstObject);
        Instantiate(bottelObject, firstObject.transform);
        Instantiate(capObject, nextObject.transform);
    }

    /// <summary>
    /// クリックによる分解をする関数
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (firstObject.name == "Plastic_bottle")
        {
            Separation();
        }
        else
        {

        }
    }
}
