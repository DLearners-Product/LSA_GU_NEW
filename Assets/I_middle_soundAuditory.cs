using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_middle_soundAuditory : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] audioClip;

    int songNumber;

    private void Start()
    {
        songNumber = 0;
        this.gameObject.transform.Find("speaker").gameObject.GetComponent<speaker_audit>().clip = audioClip[songNumber];
    }

    public void NextSong()
    {
        songNumber++;

        if (songNumber == 15)
        {
            songNumber = 0;
        }

        this.gameObject.transform.Find("speaker").gameObject.GetComponent<speaker_audit>().clip = audioClip[songNumber];
    }
}