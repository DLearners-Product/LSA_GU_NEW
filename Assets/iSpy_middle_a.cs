using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class iSpy_middle_a : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject shade;

    public int object_count;
    public Text scoreText;

    public List<string> attempts;

    public AudioSource audioSource;

    public GameObject selectedGameObject;

    public IDictionary<string, Sprite> shadeTextImage;
    public Sprite[] shadeTextSprite;

    private void Start()
    {
        shadeTextImage = new Dictionary<string, Sprite>();
        shadeTextImage.Add("rut", shadeTextSprite[0]);
        shadeTextImage.Add("sun", shadeTextSprite[1]);
        shadeTextImage.Add("mud", shadeTextSprite[2]);
        shadeTextImage.Add("rub", shadeTextSprite[3]);
        shadeTextImage.Add("fun", shadeTextSprite[4]);
        shadeTextImage.Add("nun", shadeTextSprite[5]);
        shadeTextImage.Add("gut", shadeTextSprite[6]);
        object_count = 0;
    }
    public void ImgHighlight(AudioClip clip)
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;

        audioSource.PlayOneShot(clip);

        attempts.Add(selectedGameObject.name);
        Debug.Log(selectedGameObject);

        if (selectedGameObject.CompareTag("answer"))
        {
            StartCoroutine(DisplayShade(selectedGameObject));
        }
    }

    IEnumerator DisplayShade(GameObject selectedGameObject)
    {
        object_count++;
        scoreText.text = ""+ object_count;

        for (int i=0; i< objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
        selectedGameObject.GetComponent<Button>().enabled = false;
        shade.SetActive(true);

        shade.gameObject.transform.Find("Image").GetComponent<Image>().sprite = shadeTextImage[selectedGameObject.name];

        yield return new WaitForSeconds(1.5f);

        shade.SetActive(false);

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }

        if(object_count >= 7)
        {
           //   Main_Blended.OBJ_main_blended.PostDataToDB("a_iSpyMiddle", attempts);   //TODO: DB
        }
    }

    public void Ispy_Reset()
    {
        object_count = 0;
        scoreText.text = "" + object_count;
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<Button>().enabled = true;
        }
    }
}