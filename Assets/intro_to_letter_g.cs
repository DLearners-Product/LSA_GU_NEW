using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_to_letter_g : MonoBehaviour
{
    public GameObject[] All_G_btn;
    public int displayCount;

    private void Start()
    {
        displayCount = 0;

        for(int i = 0; i< All_G_btn.Length; i++)
        {
            All_G_btn[i].SetActive(false);
        }
        All_G_btn[displayCount].SetActive(true);
    }

    public void ChangeBtn()
    {
        if(displayCount >= 3)
        {
           Debug.Log("Game Over");
        }
        else
        {
            displayCount++;
            All_G_btn[displayCount].SetActive(true);
        }
    }
}
