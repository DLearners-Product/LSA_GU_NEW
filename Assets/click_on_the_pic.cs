using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class click_on_the_pic : MonoBehaviour
{
    GameObject selectedGameObject;

    public GameObject shade;
    public GameObject FinishScreen;
    public GameObject objetcs;
    int count;

    public Sprite[] textImage;


    private void Start()
    {
        count = 0;
        shade.SetActive(false);
        FinishScreen.SetActive(false);

        for(int i=0; i<objetcs.transform.childCount; i++)
        {
            objetcs.transform.GetChild(i).GetComponent<Button>().enabled = false;
            objetcs.transform.GetChild(i).GetComponent<HoverAudio>().enabled = false;
        }
        Invoke("MakeDelay", 2f);
    }
    void MakeDelay()
    {
        if(this.GetComponent<Animator>() != null)
            this.GetComponent<Animator>().enabled = true;
        for (int i = 0; i < objetcs.transform.childCount; i++)
        {
            objetcs.transform.GetChild(i).GetComponent<Button>().enabled = true;
            objetcs.transform.GetChild(i).GetComponent<HoverAudio>().enabled = true;
        }
    }

    public void Click_Me()
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;

        if (selectedGameObject.CompareTag("answer"))
        {
            if (selectedGameObject.name == "umbrella") shade.transform.Find("TextImage").GetComponent<Image>().sprite = textImage[0];
            if (selectedGameObject.name == "unicorn") shade.transform.Find("TextImage").GetComponent<Image>().sprite = textImage[1];
            if (selectedGameObject.name == "unicycle") shade.transform.Find("TextImage").GetComponent<Image>().sprite = textImage[2];

           count++;
            shade.SetActive(true);
            shade.transform.GetChild(0).GetComponent<Image>().sprite = selectedGameObject.GetComponent<Image>().sprite;

            StartCoroutine(DisableGameObject());
        }
    }

    

    IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(1.5f);
        shade.SetActive(true);
        selectedGameObject.GetComponent<Image>().color = new Color32(247, 144, 33, 255);
        selectedGameObject.GetComponent<Button>().enabled = false;
        selectedGameObject.GetComponent<HoverAudio>().enabled = false;
        shade.SetActive(false);

        if (count >=3)
        {
            yield return new WaitForSeconds(.5f);
            FinishScreen.SetActive(true);
        }
    }
}