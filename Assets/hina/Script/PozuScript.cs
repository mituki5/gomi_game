using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PozuScript : MonoBehaviour
{
    static float time;

    [SerializeField] GameObject pozu;
    [SerializeField] Button REGameBottun;

    // Start is called before the first frame update
    void Start()
    {
        pozu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Pozu_Bottun()
    {
        PozuGame();
        pozu.SetActive(true);
    }

    public void PozuGame()
    {
        Time.timeScale = 0;
    }

    public void REGame_Bottun()
    {
        pozu.SetActive(false);
        Time.timeScale = 1;
    }
}
