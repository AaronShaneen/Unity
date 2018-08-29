using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;

    public void ShowHideBubble()
    {
        StartCoroutine(ShowHide());
    }

    IEnumerator ShowHide()
    {
        panel.SetActive(true);
        text.SetActive(true);
        yield return new WaitForSeconds(2);
        text.SetActive(false);
        panel.SetActive(false);
    }
}