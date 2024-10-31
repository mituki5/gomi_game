using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class DecisionScript : MonoBehaviour
{
    [SerializeField] GameObject correctAnswer;
    [SerializeField] GameObject incorrectAnswer;

    private static GameObject trash;
    private static GameObject plastic;
    private static GameObject bottle;

    void Start()
    {
        correctAnswer.SetActive(false);
        incorrectAnswer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(trash.GetComponent<Moerugomi>().isEnter == true)
        {
            CorrectAnswerImage();
            trash.GetComponent<Moerugomi>().isEnter = false;
        }
        if (plastic.GetComponent<Plasticgomi>().isEnter == true)
        {
            CorrectAnswerImage();
            plastic.GetComponent<Plasticgomi>().isEnter = false;
        }

        if (bottle.GetComponent<Plasticbottle>().isEnter == true)
        {
            CorrectAnswerImage();
            bottle.GetComponent<Plasticbottle>().isEnter = false;
        }
        if (trash.GetComponent<Moerugomi>().mistake == true || plastic.GetComponent<Plasticgomi>().mistake == true || bottle.GetComponent<Plasticbottle>().mistake == true)
        {
            IncorrectAnswerImage();
            trash.GetComponent<Moerugomi>().mistake = false;
            plastic.GetComponent<Plasticgomi>().mistake = false;
            bottle.GetComponent<Plasticbottle>().mistake = false;
        }
    }

    private IEnumerator CorrectAnswerImage()
    {
        correctAnswer.SetActive(true);
        yield return new WaitForSeconds(3);
        correctAnswer.SetActive(false);
    }

    private IEnumerator IncorrectAnswerImage()
    {
        incorrectAnswer.SetActive(true);
        yield return new WaitForSeconds(3);
        incorrectAnswer.SetActive(false);
    }
}
