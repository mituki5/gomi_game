using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PozuScript : MonoBehaviour
{
    static float time;
    public static float Score;

    [SerializeField] GameObject pozu;

    // Start is called before the first frame update
    void Start()
    {
        pozu.SetActive(false);
        Time.timeScale = 1;
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

    public void RTGame_Bottun()
    {
        pozu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Main_Bottun()
    {
        Time.timeScale = 1;
    }
}
