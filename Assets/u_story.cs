using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class u_story : MonoBehaviour
{
    public GameObject[] Questions;
    public GameObject finishScreen;

    GameObject selectedTextObject;
    public AudioSource audioSource;


    int questionCount;

    private void Start()
    {
        questionCount = 0;
        finishScreen.SetActive(false);
        NextQuestion();
    }

    public void ClickQuestion(AudioClip audioClip)
    {
        questionCount++;
        selectedTextObject = EventSystem.current.currentSelectedGameObject;

        selectedTextObject.gameObject.SetActive(false);

        selectedTextObject.transform.parent.gameObject.transform.Find("AnswerTxt").gameObject.SetActive(true);

        audioSource.clip = audioClip;
        audioSource.Play();

        Invoke("MakeDelay", 2f);
    }

    void MakeDelay()
    {
        NextQuestion();
    }

    void NextQuestion()
    {

        for(int i = 0; i< Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }

        if (Questions.Length == questionCount)
        {
            finishScreen.SetActive(true);
        }
        else
        {
            Questions[questionCount].SetActive(true);
        }
    }
}
