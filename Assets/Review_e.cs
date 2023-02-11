using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Review_e : MonoBehaviour
{
    public void MakeReview()
    {
        this.gameObject.transform.Find("hand").GetComponent<Animator>().Play("e_hand_review_anim_2");
    }
}