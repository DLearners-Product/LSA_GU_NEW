using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class color_the_letter : MonoBehaviour
{
    GameObject selectedGameObject;
    string colorName;

    public GameObject[] Questions;
    public AudioSource audioSource;

    public GameObject MousePointer;
    private Vector2 mousePosition;
    float moveSpeed = 0.1f;
    bool canPoint;

    int questionCount;

    private void Start()
    {
        questionCount = 0;
        Questions[questionCount].SetActive(true);
        canPoint = true;
    }

    private void Update()
    {
        if (canPoint)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            MousePointer.transform.position = mousePosition;
        }
    }

    public void ColorMe(AudioClip audioClip)
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;

        if(selectedGameObject.CompareTag("letters"))
        {
            if(colorName != null)
            {
                if(colorName == "blue") MousePointer.GetComponent<Image>().color = new Color32(0, 174, 235, 255);
                if (colorName == "green") MousePointer.GetComponent<Image>().color = new Color32(20, 176, 77, 255);
                if (colorName == "rose") MousePointer.GetComponent<Image>().color = new Color32(240, 97, 141, 255);
                if (colorName == "orange") MousePointer.GetComponent<Image>().color = new Color32(249, 159, 30, 255);
 
                if (colorName == "no_color")
                {
                    for(int i = 0; i< selectedGameObject.transform.childCount; i++)
                    {
                        selectedGameObject.transform.GetChild(i).gameObject.SetActive(false);
                        MousePointer.GetComponent<Image>().color = new Color(255, 255, 255); // no color
                    }
                }
                else
                {
                    for (int i = 0; i < selectedGameObject.transform.childCount; i++)
                    {
                        selectedGameObject.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    selectedGameObject.transform.Find(colorName).gameObject.SetActive(true);

                    if (selectedGameObject.transform.parent.tag == colorName)
                    {
                        audioSource.clip = audioClip;
                        audioSource.Play();
                    }
                }
            }
        }
    }

    public void ChangeColor()
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;

        if (selectedGameObject.CompareTag("color"))
        {
            colorName = selectedGameObject.name;

            Debug.Log("color name : " + colorName);

            if (colorName == "blue") MousePointer.GetComponent<Image>().color = new Color32(0, 174, 235, 255);
            if (colorName == "green") MousePointer.GetComponent<Image>().color = new Color32(20, 176, 77, 255);
            if (colorName == "rose") MousePointer.GetComponent<Image>().color = new Color32(240, 97, 141, 255);
            if (colorName == "orange") MousePointer.GetComponent<Image>().color = new Color32(249, 159, 30, 255);

            if (colorName == "no_color")
            {
                for (int i = 0; i < selectedGameObject.transform.childCount; i++)
                {
                    selectedGameObject.transform.GetChild(i).gameObject.SetActive(false);
                    MousePointer.GetComponent<Image>().color = new Color(255, 255, 255); // no color
                }
            }


        }
    }


    public void NextQuestion()
    {
        if(questionCount == Questions.Length - 1)
        {
            questionCount = 0;
        }
        else
        {
            questionCount++;
        }

        for (int i=0; i< Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }

        Questions[questionCount].SetActive(true);
    }

    public void PreviousQuestion()
    {
        if (questionCount == 0)
        {
            questionCount = Questions.Length - 1;
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
    }
}