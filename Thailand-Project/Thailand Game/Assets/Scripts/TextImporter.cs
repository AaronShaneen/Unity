using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour {

    public TextAsset textFile;
    public string[] textLines;
    public GameObject textBox;
    public Text theText;
    public int storyLine;

	// Use this for initialization
	void Start () {
	
        if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
	}

    private void Update()
    {
        theText.text = textLines[storyLine];
    }
}