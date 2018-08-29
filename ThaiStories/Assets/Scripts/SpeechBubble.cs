using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public GameObject wordPanel;
    public GameObject audioPanel;

    public void ShowHideBubble()
    {

        if(wordPanel.activeSelf && audioPanel.activeSelf)
        {
            wordPanel.SetActive(false);
            audioPanel.SetActive(false);
        }

        else
        {
            wordPanel.SetActive(true);
            audioPanel.SetActive(true);
        }
    }
}