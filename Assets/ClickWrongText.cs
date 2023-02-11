using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickWrongText : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 231, 205, 255);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        audioSource.clip = audioClip;
        audioSource.Play();

        this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);   //red
    }
}
