using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void Start_Button()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Restart_Button()
    {
        SceneManager.LoadScene("RestartScens");
    }

    public void MainGame_Button()
    {
        SceneManager.LoadScene("MainScene");
    }
}
