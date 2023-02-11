using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class speaker_audit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    public AudioSource audioSource;
    public AudioClip clip;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        audioSource.PlayOneShot(clip);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
