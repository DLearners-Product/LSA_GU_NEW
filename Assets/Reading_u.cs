using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reading_u : MonoBehaviour
{
    public GameObject TextImage;

    public Sprite[] All_u_textImage;

    public AudioSource audioSource;
    public AudioClip[] audioClip;

    int textCount;

    private void Start()
    {
        textCount = 0;
    }

    public void NextText()
    {
        if (textCount >= 4)
        {
            textCount = 0;
        }

        TextImage.GetComponent<Image>().sprite = All_u_textImage[textCount];

        audioSource.clip = audioClip[textCount];
        audioSource.Play();

        textCount++;
    }

    public void PlayAudio()
    {
        if (textCount != 0)
        {
            audioSource.clip = audioClip[textCount];
            audioSource.Play();
        }
    }
}
