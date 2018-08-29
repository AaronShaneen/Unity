using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble2 : MonoBehaviour
{
    public GameObject wordPanel;

    public void ShowHideBubble()
    {
        StartCoroutine(ShowHide());
    }

    IEnumerator ShowHide()
    {
        wordPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        wordPanel.SetActive(false);
    }
}