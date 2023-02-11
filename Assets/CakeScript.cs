using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CakeScript : MonoBehaviour
{
    public GameObject DestinationPos;
    public GameObject shade;

    public AudioSource audioSource;
    public AudioClip audioClip;
    GameObject selectedGameObject;

    public bool canLerp;


    public Vector2 cakeInitalPos;

    private void Start()
    {
        cakeInitalPos = this.transform.position;
        canLerp = false;
    }
    private void Update()
    {
        if (canLerp)
        {
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, DestinationPos.transform.position, 2f * Time.deltaTime);
            this.gameObject.transform.localScale = new Vector2(2, 2);
        }
    }
    public void CakeLerp()
    {
        if (this.transform.gameObject.CompareTag("answer"))
        {
            canLerp = true;
            selectedGameObject = this.gameObject;

            StartCoroutine(ShadeDelay());
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
    IEnumerator ShadeDelay()
    {
        yield return new WaitForSeconds(.5f);
        
        shade.SetActive(true);
        audioSource.PlayOneShot(audioClip);

        selectedGameObject.GetComponent<Button>().enabled = false;

        char firstLetter = selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.ToString()[0];
        char middleLetter = selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.ToString()[1];
        char lastLetter = selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.ToString()[2];
        shade.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText(firstLetter + "<#F7E73D>" + middleLetter + "</color>" + lastLetter);

        yield return new WaitForSeconds(1f);
        shade.SetActive(false);

        this.transform.parent.transform.parent.gameObject.GetComponent<I_middleEval_visual>().IncreaseCakeCount();  //
        selectedGameObject.SetActive(false);

    }
}