using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_middleEval_spinWheel : MonoBehaviour
{

    GameObject selectedGameObject;
    GameObject LerpObject;

    public GameObject spinWheel;
    public GameObject spin_i;

    public GameObject objects;  //lerp objects
    public AudioSource audioSource;
    public AudioClip clip;
    public int count;

    private void Start()
    {
        count = 0;
    }

    private void Update()
    {

        if(count >= 4)
        {
            Debug.Log("Pig animation");
        }

        Rotate_spinWheel();

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                selectedGameObject = hit.collider.gameObject;

                if (selectedGameObject.CompareTag("answer"))
                {
                    if (selectedGameObject.name == "pig")
                    {
                        objects.transform.Find("pig").gameObject.SetActive(true);
                        objects.transform.Find("pig").GetComponent<PigScript>().MakeLerp(new Vector3(5, 5, 0));
                    }
                    if (selectedGameObject.name == "wig")
                    {
                        objects.transform.Find("wig").GetComponent<PigScript>().MakeLerp(new Vector3(2, 2, 0));
                    }

                    if (selectedGameObject.name == "lip")
                    {
                        objects.transform.Find("lip").GetComponent<PigScript>().MakeLerp(new Vector3(1.5f, 1.5f, 0));
                    }
                    if (selectedGameObject.name == "pin")
                    {
                        objects.transform.Find("pin").GetComponent<PigScript>().MakeLerp(new Vector3(1.5f, 1.5f, 0));
                    }
                }
                else
                {
                    audioSource.PlayOneShot(clip);
                }
            }
        }
    }

    void Rotate_spinWheel()
    {
        spinWheel.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 5f * Time.deltaTime));
    }

    public void IncreaseCount()
    {
        count++;
    }

    public void Reset()
    {
        count = 0;

        for(int i = 0; i< objects.transform.childCount; i++)
        {
            objects.transform.GetChild(i).GetComponent<PigScript>().canLerp = false;
            objects.transform.GetChild(i).GetComponent<PigScript>().canIncreaseCount = true;
            objects.transform.GetChild(i).transform.position = spin_i.transform.position;
        }
    }
}