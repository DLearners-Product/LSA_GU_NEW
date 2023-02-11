using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class welcomeScript : MonoBehaviour
{
    public void Reset()
    {


        this.gameObject.GetComponent<Animator>().enabled = false;
        Invoke("MakeDelay", .5f);
    }

    void MakeDelay()
    {
        Debug.Log("Welcome Reset");
        this.gameObject.GetComponent<Animator>().enabled = true;
    }
}