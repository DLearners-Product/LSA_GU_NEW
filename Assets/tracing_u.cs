using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracing_u : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject[] u_pieces;
    public GameObject[] dots;


    private void Start()
    {
        for (int i = 0; i < u_pieces.Length; i++)
        {
            u_pieces[i].SetActive(false);
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
        if (number >= 3)
        {
            Debug.Log("Crash here");
            u_pieces[number].SetActive(true);
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {

            u_pieces[number].SetActive(true);
            dots[number + 2].SetActive(true);

            audioSource.clip = audioClip;
            audioSource.Play();
        }

    }
}
