using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class look_at_the_picture_say : MonoBehaviour
{
    public GameObject DisplayImage;
    public GameObject DisplayTextImage;

    public AudioSource audioSource;
    GameObject selectedGameObject;
    Sprite currentSelectedGO_text;
    Sprite currentSelectedGO_Image;

    AudioClip audioClip;
    private void Start()
    {
        DisplayImage.SetActive(false);
        DisplayTextImage.SetActive(false);
    }

    public void ShowImageInPanel(AudioClip clip)
    {
        audioClip = clip;

        DisplayImage.SetActive(true);
        DisplayTextImage.SetActive(false);

        selectedGameObject = EventSystem.current.currentSelectedGameObject;

        currentSelectedGO_Image = selectedGameObject.transform.Find("ShowImage").gameObject.GetComponent<Image>().sprite;



        audioSource.clip = audioClip;
        audioSource.Play();

        DisplayImage.GetComponent<Image>().sprite = currentSelectedGO_Image;
    }


    public void ShowTextImage()
    {
        DisplayTextImage.SetActive(true);
        currentSelectedGO_text = selectedGameObject.transform.Find("TextImage").gameObject.GetComponent<Image>().sprite;
        DisplayTextImage.GetComponent<Image>().sprite = currentSelectedGO_text;

        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
