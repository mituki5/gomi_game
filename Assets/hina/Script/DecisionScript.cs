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
        if(trash.GetComponent<TrashBox>().isEnter == true)
        {
            CorrectAnswerImage();
            trash.GetComponent<TrashBox>().isEnter = false;
        }
        //if (plastic.GetComponent<PlasticBox>().isEnter == true)
        //{
        //    CorrectAnswerImage();
        //    plastic.GetComponent<PlasticBox>().isEnter = false;
        //}

        //if (bottle.GetComponent<BottleBox>().isEnter == true)
        //{
        //    CorrectAnswerImage();
        //    bottle.GetComponent<BottleBox>().isEnter = false;
        //}
        if (trash.GetComponent<TrashBox>().mistake == true || plastic.GetComponent<PlasticBox>().mistake == true || bottle.GetComponent<BottleBox>().mistake == true)
        {
            IncorrectAnswerImage();
            trash.GetComponent<TrashBox>().mistake = false;
            plastic.GetComponent<PlasticBox>().mistake = false;
            bottle.GetComponent<BottleBox>().mistake = false;
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
