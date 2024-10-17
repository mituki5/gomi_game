using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public float countdown = 30.0f;

    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        timeText.text = "Žc‚è" + countdown.ToString("f1") + "•b";

        if(countdown <= 0)
        {
            timeText.text = "I—¹I";
        }
    }
}
