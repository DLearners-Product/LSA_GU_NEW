using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class I_middleEval_visual : MonoBehaviour
{
    public GameObject[] cakes_piecesPos;
    public GameObject tray;
    public int answerCount;

    public AudioSource audioSource;
    public GameObject cake_ready;   //  final show-off sprite


    public GameObject[] AllCakePieces;

    Vector2 tray_InitalPos;

    private void Start()
    {
        tray_InitalPos = tray.transform.position;
        //TurnOffAllCakes();
        answerCount = 0;
    }

    private void Update()
    {
        if (answerCount >= 6)
        {
            cake_ready.SetActive(true);
            tray.transform.parent.gameObject.GetComponent<Animator>().enabled = true;        //cake tray 
        }
    }
    public void IncreaseCakeCount()
    {
        cakes_piecesPos[answerCount].SetActive(true);
        answerCount++;
    }

    public void Reset()
    {
        Debug.Log("Reset");
        answerCount = 0;

        cake_ready.SetActive(false);

        for(int i = 0; i < cakes_piecesPos.Length; i++)
        {
            cakes_piecesPos[i].SetActive(false);
        }

        for (int i = 0; i < AllCakePieces.Length; i++)
        {
            AllCakePieces[i].GetComponent<CakeScript>().canLerp = false;
            AllCakePieces[i].transform.position =  AllCakePieces[i].GetComponent<CakeScript>().cakeInitalPos;
            AllCakePieces[i].transform.localScale = new Vector2(1, 1);
            AllCakePieces[i].GetComponent<Button>().enabled = true;
            AllCakePieces[i].SetActive(true);
        }

        tray.transform.parent.gameObject.GetComponent<Animator>().enabled = false;
        tray.transform.position = tray_InitalPos;
    }
}