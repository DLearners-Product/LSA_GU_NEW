using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Review_o : MonoBehaviour
{
    public AudioSource source;

    public GameObject hand_vowels;


    public Vector2 handPos;

    private void Start()
    {
        handPos = this.transform.Find("hand_vowels").transform.Find("hand").transform.position;
      //  this.transform.Find("hand_vowels").GetComponent<Animator>().SetInteger("handCondition", 1);
        //this.transform.Find("hand_vowels").GetComponent<Animator>().SetInteger("handCondition", 5);
    }

    public void play_i()
    {
        hand_vowels.GetComponent<Animator>().SetInteger("handCondition", 1);
    }

    public void PlayAudio(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void Reset()
    {
        this.transform.Find("hand_vowels").transform.Find("hand").transform.position = new Vector2(0.8f, -114.2f);
        this.transform.Find("hand_vowels").GetComponent<Animator>().SetInteger("handCondition", 5);
    }

}
