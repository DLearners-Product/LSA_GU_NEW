using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragScript : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 intialPos;

    bool canDrag;
    public bool IsCorrect;

    GameObject otherGameObject;

    bool clickOnce;

    private void Start()
    {
        clickOnce = true;
        canDrag = false;
        IsCorrect = false;
        intialPos = this.GetComponent<Transform>().position;        // current object inital position
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (canDrag && !IsCorrect)
        {
            Debug.Log("1");
            this.transform.position = mousePos;
        }
        if (!canDrag && !IsCorrect)
        {
            Debug.Log("2");
            this.transform.position = intialPos;
        }

        if (!canDrag && IsCorrect)
        {
            Debug.Log("3");
            this.transform.position = otherGameObject.transform.position;
        }
    }

    private void OnMouseUp()
    {
        canDrag = false;
    }
    private void OnMouseDown()
    {
        canDrag = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        /*Debug.Log("Crash name : " + this.gameObject.name);
        Debug.Log("Crash tag : " + other.gameObject.tag);*/

        if (this.gameObject.tag == other.gameObject.tag)
        {
            Debug.Log("correct answer");

            otherGameObject = other.gameObject;
            if (Input.GetMouseButtonUp(0))
            {

                IsCorrect = true;
                Debug.Log("CRash : Audio can play");

                if (clickOnce)
                {
                    this.gameObject.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<matching_u>().IncreaseCount(this.gameObject.tag);
                    clickOnce = false;
                }
            }
        }
    }
}