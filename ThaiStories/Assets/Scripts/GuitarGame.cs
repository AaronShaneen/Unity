using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GuitarGame : MonoBehaviour
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
        PlaySound();
    }

    // Update is called once per frame
    void Update()
    {

        //theText.text = textLines[currentLine];


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