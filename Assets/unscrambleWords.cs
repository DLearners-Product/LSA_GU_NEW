using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unscrambleWords : MonoBehaviour
{
    public static unscrambleWords _UnscrambleWords;
    public int count;
    public GameObject[] unScrambleWdsQuestions;

    public Sprite normalPlaceholder;

    public GameObject FinishScreen;

    private void Start()
    {
        FinishScreen.SetActive(false);
        count = 0;
        _UnscrambleWords = this;
        StartCoroutine(NextShuffle(0));
    }

    public IEnumerator NextShuffle(float seconds)
    {
        if(unScrambleWdsQuestions != null)
        if (count >=6)
        {

            yield return new WaitForSeconds(seconds);

            for (int i = 0; i < unScrambleWdsQuestions.Length; i++)
            {
                unScrambleWdsQuestions[i].SetActive(false);
            }
            for (int i = 0; i < this.gameObject.transform.Find("BG").childCount; i++)
            {
                this.gameObject.transform.Find("BG").GetChild(i).gameObject.SetActive(false);
            }
            FinishScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Crash count" + count);
            yield return new WaitForSeconds(seconds);

            for (int i = 0; i < unScrambleWdsQuestions.Length; i++)
            {
                unScrambleWdsQuestions[i].SetActive(false);
            }
            unScrambleWdsQuestions[count].SetActive(true);
            count++;
        }
    }

    public void Reset()
    {
        count = 0;
        StartCoroutine(NextShuffle(0));
        FinishScreen.SetActive(false);

        for (int i = 0; i < this.gameObject.transform.Find("BG").childCount; i++)
        {
            this.gameObject.transform.Find("BG").GetChild(i).gameObject.SetActive(true);
        }


        for (int i=0; i< unScrambleWdsQuestions.Length; i++)
        {
            //unScrambleWdsQuestions[i].GetComponent<Questions>().questionCount = 3;

            for(int j =0; j< unScrambleWdsQuestions[i].transform.childCount; j++)
            {

                unScrambleWdsQuestions[i].transform.Find("slot_1").GetComponent<Image>().sprite = normalPlaceholder;
                unScrambleWdsQuestions[i].transform.Find("slot_2").GetComponent<Image>().sprite = normalPlaceholder;
                unScrambleWdsQuestions[i].transform.Find("slot_3").GetComponent<Image>().sprite = normalPlaceholder;

                if (unScrambleWdsQuestions[i].transform.GetChild(j).gameObject.CompareTag("occupied"))
                {
                    unScrambleWdsQuestions[i].transform.GetChild(j).gameObject.tag = "Untagged";
                    unScrambleWdsQuestions[i].transform.GetChild(j).GetComponent<Image>().sprite = normalPlaceholder;
                   // unScrambleWdsQuestions[i].transform.GetChild(j).Find("ray").GetComponent<Image>().sprite = blueRay;
                }
               /* if (unScrambleWdsQuestions[i].transform.GetChild(j).GetComponent<DragScript>() != null)
                {
                    Debug.Log("drag script is null");
                    //unScrambleWdsQuestions[i].transform.GetChild(j).GetComponent<DragScript>().IsCorrect = false;
                    //unScrambleWdsQuestions[i].transform.GetChild(j).GetComponent<DragScript>().ToCallDecreaseFuncOnce = true;
                }*/
            }
        }
    }

}