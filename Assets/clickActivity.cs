using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class clickActivity : MonoBehaviour
{
    public GameObject destinationPos;
    public GameObject movingObj;

    public GameObject TurnOnTextImage;

    bool canLerp;

    public Vector2 initalPos;

    string ChangeTextColor;

    public GameObject clickObject;

    bool canChangeColor;
    string text;

    private void Start()
    {
        canChangeColor = true;
        canLerp = false;
        initalPos = movingObj.transform.position;
    }

    private void Update()
    {
        if (canLerp)
        {
            movingObj.transform.position = Vector3.Lerp(movingObj.transform.position, destinationPos.transform.position, 3f * Time.deltaTime);

            if (movingObj.transform.gameObject.CompareTag("u_intro"))
            {
                movingObj.transform.localScale = new Vector2(3f, 3f);
            }
            else
            {
                //movingObj.transform.localScale = new Vector2(1.4f, 1.4f);
            }


            Invoke("MakeDelay", .8f);

        }
    }

    public void Click_startLerp()
    {
        clickObject = EventSystem.current.currentSelectedGameObject;
        movingObj.SetActive(true);

        Debug.Log("Crash lerp : " + clickObject.gameObject.name);
        canLerp = true;

        if(this.transform.parent.gameObject.transform.parent.gameObject.GetComponent<intro_to_letter_g>() != null)  // intro to letter g - game
        {
            this.transform.parent.gameObject.transform.parent.gameObject.GetComponent<intro_to_letter_g>().ChangeBtn();
        }

        if (this.transform.parent.gameObject.GetComponent<intro_to_u>() != null) // intro to letter u - game
        {
            this.transform.parent.gameObject.GetComponent<intro_to_u>().ChangeBtn();
        }
    }

    void MakeDelay()
    {
        TurnOnTextImage.SetActive(true);
    }


    public void Reset()
    {
       // this.transform.Find("letters").transform.Find("u").GetComponent<Animator>().enabled = false;
        movingObj.transform.position = initalPos;
        if (clickObject != null)
        {
            canChangeColor = true;
            canLerp = false;
        }
    }
}