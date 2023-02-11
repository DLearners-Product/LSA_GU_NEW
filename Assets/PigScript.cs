using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigScript : MonoBehaviour
{

    public GameObject destinationPos;

    public bool canLerp;

    Vector2 scaler;

    public AudioSource audioSource;
    public AudioClip clip;


    public bool canIncreaseCount;

    private void Start()
    {
        canIncreaseCount = true;
    }

    private void Update()
    {
        if (canLerp)
        {
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, destinationPos.transform.position, 2f * Time.deltaTime);
            this.gameObject.transform.localScale = scaler;
        }
    }

    public void MakeLerp(Vector2 vector)
    {
        this.gameObject.SetActive(true);
        scaler = vector;
        audioSource.PlayOneShot(clip);
        canLerp = true;

        if (canIncreaseCount)
        {
            this.transform.parent.transform.parent.GetComponent<I_middleEval_spinWheel>().IncreaseCount();
            canIncreaseCount = false;
        }
    }
}