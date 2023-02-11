using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class u_middle_soundEval_visual : MonoBehaviour
{

    public GameObject[] AllApplesInBasket;
    public GameObject[] AllApplesInTree;
 
    GameObject selectedApples;
    public GameObject basket;
    public int applesCount;

    public AudioSource audioSource;
    public AudioClip wrongAudio;

    public GameObject FinishScreen;

    public static u_middle_soundEval_visual objects_;

    private void Start()
    {

        FinishScreen.SetActive(false);
        objects_ = this;
        applesCount = 0;
        for (int i=0; i<AllApplesInBasket.Length; i++)
        {
            AllApplesInBasket[i].SetActive(false);
        }
    }

    public void SelectApples()
    {
        selectedApples = EventSystem.current.currentSelectedGameObject;

      //  basket.GetComponent<basketScript>().targetPos = selectedApples.transform.position.x;

        if (selectedApples.CompareTag("answer"))
        {
            TurnOffApples(false);

            applesCount++;

            selectedApples.GetComponent<Rigidbody2D>().gravityScale = 1;
            selectedApples.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

           // AllApplesInBasket[applesCount - 1].SetActive(true);
           // AllApplesInBasket[applesCount-1].transform.GetChild(0).GetComponent<Image>().sprite = selectedSprite;
        }
        else
        {
            audioSource.clip = wrongAudio;
            audioSource.Play();
        }

        if (applesCount >= 9)
        {
            Invoke("MakeDelay", 1.5f);
        }
    }

    void MakeDelay()
    {
        FinishScreen.SetActive(true);
    }

    public void TurnOffApples(bool x)
    {
        for(int i=0;i < AllApplesInTree.Length; i++)
        {
            AllApplesInTree[i].GetComponent<Button>().enabled = x;
        }
    }

    public void Reset()
    {
        applesCount = 0;
        FinishScreen.SetActive(false);

        for (int i = 0; i < AllApplesInTree.Length; i++)
        {
            //AllApplesInTree[i].GetComponent<appleScript>().collided = false;
           // AllApplesInTree[i].transform.position = AllApplesInTree[i].GetComponent<appleScript>().initalPos;

            if (AllApplesInTree[i].GetComponent<Rigidbody2D>() != null)
            {
                AllApplesInTree[i].GetComponent<Rigidbody2D>().gravityScale = 0;
                AllApplesInTree[i].GetComponent<Collider2D>().enabled = true;

                AllApplesInTree[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //AllApplesInTree[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }


            

            
        }
        TurnOffApples(true);
    }
}