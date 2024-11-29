using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class KindsSub : MonoBehaviour
{
    public GameObject nextObject;
    private kinds kindScript;
    private ThrowingPower firstThrowingpower;

    [SerializeField] private List<GameObject> trashPrefabs = new List<GameObject>();

    // éüÇÃÉSÉ~Çê∂ê¨
    public void StartnextObjectInstantiate()
    {
        int tmpIndex = Random.Range(0, kindScript._name.Count);
        kindScript.nextObject = Instantiate(trashPrefabs[tmpIndex], this.transform);
        kindScript.nextIndex = tmpIndex;

    }

    public void SecondInstantiateTrash()
    {
        // êVÇµÇ¢ÉSÉ~Çê∂ê¨
        kindScript.nextIndex = (int)Random.Range(0, kindScript._name.Count);
        kindScript.nextObject.name = kindScript._name[kindScript.index];
        kindScript.nextObject = Instantiate(trashPrefabs[kindScript.index], transform);
    }

}
