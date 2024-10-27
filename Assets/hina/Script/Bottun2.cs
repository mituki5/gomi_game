using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bottun2 : MonoBehaviour
{
    public void Title_Bottun()
    {
        SceneManager.LoadScene("Title");
    }

    public void Game_Bottun()
    {
        SceneManager.LoadScene("GameScene 1");
    }
}
