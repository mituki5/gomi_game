using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;

public class Bottun2 : MonoBehaviour
{
    public static float Score;
    PozuScript PozuScript;

    public void Title_Bottun()
    {
        SceneManager.LoadScene("Title");
    }

    public void MainGame_Bottun()
    {
        SceneManager.LoadScene("GameScene 1");
    }

    public void RTGame_Bottun()
    {
        Score = 0;
        SceneManager.LoadScene("GameScene 1");
    }


}
