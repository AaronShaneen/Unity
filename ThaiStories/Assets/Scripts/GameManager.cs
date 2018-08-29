using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text userName;
    public Text playerName;
    public GameObject gameUI;
    public GameObject menuUI;
    //public GameObject textManager;

   /* void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }*/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Called when submit button is pressed, checks the login info, then sets things in motion if it's correct
    public void checkLogin()
    {
        //do stuff

        //if good set player name, enable gameui, disable menuui
        playerName.text = userName.text;
        gameUI.SetActive(true);
        menuUI.SetActive(false);
        //textManager.SetActive(true);
        //load scene based on what level player is on -- current code is temporary
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Can force destroy this if needed
    public void Destroy()
    {
        DestroyObject(gameObject);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    /* might need as other way to do game manager*/
    public static GameManager instance = null;

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
}
