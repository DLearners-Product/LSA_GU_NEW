using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class listening_the_game : MonoBehaviour
{

    public GameObject[] Questions;

    GameObject selectedGameObject;
    public AudioSource audioSource;
    public AudioClip click;

    public int questionCount;

    //particles
    [SerializeField] private ParticleSystem prevParticle;
    [SerializeField] private ParticleSystem nextParticle;

    //text
    [SerializeField] private TextMeshProUGUI counterText;

    private void Start()
    {
        for (int i = 0; i < Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }
        Questions[questionCount].SetActive(true);
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void NextScene()
    {
        nextParticle.Play();
        PlayAudio(click);

        if (questionCount >= 2)
        {
            Debug.Log("Crash End");
            questionCount = 0;
        }
        else
        {
            questionCount++;
        }
        for (int i = 0; i < Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }
        Questions[questionCount].SetActive(true);
        UpdateCounter(questionCount);
    }
    public void PreviousScene()
    {
        prevParticle.Play();
        PlayAudio(click);

        if (questionCount <= 0)
        {
            Debug.Log("Crash start");
            questionCount = 2;
        }
        else
        {
            questionCount--;
        }

        for (int i = 0; i < Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }
        Questions[questionCount].SetActive(true);
        UpdateCounter(questionCount);
    }
    public void ChangeTextColor(string coloredText)
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;

        if (selectedGameObject.CompareTag("answer"))
        {
            selectedGameObject.GetComponent<TextMeshProUGUI>().SetText(coloredText);
        }
    }

    public void UpdateCounter(int count)
    {
        counterText.text = (count + 1) + " / 3";
    }
}