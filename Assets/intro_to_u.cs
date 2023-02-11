using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_to_u : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject[] All_U_btn;
    public int displayCount;

    public AudioClip u_sound;

    private void Start()
    {
        displayCount = 0;

        for (int i = 0; i < All_U_btn.Length; i++)
        {
            All_U_btn[i].SetActive(false);
        }
        All_U_btn[displayCount].SetActive(true);
    }

    public void ChangeBtn()
    {
        if (displayCount >= 1)
        {
            audioSource.clip = u_sound;
            audioSource.Play();
        }
        else
        {
            displayCount++;
            All_U_btn[displayCount].SetActive(true);
        }
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}