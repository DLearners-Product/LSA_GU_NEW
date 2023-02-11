using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracing_g : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject[] g_pieces;
    public GameObject[] dots;


    private void Start()
    {
        for(int i=0; i<g_pieces.Length; i++)
        {
            g_pieces[i].SetActive(false);
        }
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(false);
        }
        dots[0].SetActive(true);
        dots[1].SetActive(true);
    }

    public void Trace(int number)
    {
        if(this.gameObject.name == "connect_the_g" + "(Clone)")
        {
            if (number >= 4)
            {
                g_pieces[number].SetActive(true);
                audioSource.clip = audioClip;
                audioSource.Play();
                return;
            }
        }

        if (this.gameObject.name == "trace_the_letter_g" + "(Clone)")
        {
            if (number >= 5)
            {

                g_pieces[number].SetActive(true);
                audioSource.clip = audioClip;
                audioSource.Play();
                return;
            }
        }

        g_pieces[number].SetActive(true);
        dots[number+2].SetActive(true);

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}