using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;

    public Text theText;


    public TextAsset textFile;

    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;

    //public PlayerController player;

    public AudioClip[] clips;
    public AudioMixerGroup output;
    int clipCounter = 0;

    public float minPitch = .95f;
    public float maxPitch = 1.05f;

    public static TextBoxManager instance = null;

    // Use this for initialization
    void Start()
    {
        //player = FindObjectOfType<PlayerController>();
        if (textFile != null)
        {
            string[] text = (textFile.text.Split(' '));
            textLines = (textFile.text.Split('\n')); // Every new line
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                currentLine += 1;


                if (currentLine > endAtLine)
                {
                    textBox.SetActive(false);
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                    PlaySound();
                }

            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }

        }

    }
    public void doStuff()
    {
        StartCoroutine(TextScroll(textLines[currentLine]));
        PlaySound();
        currentLine++;
    }
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            if (lineOfText[letter] == ' ')
            {
                PlaySound();
            }
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    //public void EnableTextBox()
    //{
    //    textBox.SetActive(true);
    //    isActive = true;

    //    if (stopPlayerMovement)
    //    {
    //        player.canMove = false;
    //    }

    //StartCoroutine(TextScroll(textLines[currentLine]));
    //}

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }


    public void PlaySound()
    {

        int randomClip = Random.Range(0, clips.Length);
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clips[clipCounter];
        source.outputAudioMixerGroup = output;
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
        Destroy(source, clips[clipCounter].length);
        clipCounter++;
    }
}