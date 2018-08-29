using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public Image image; //fill image
    public float numScenesInLevel;
    public GameManager gm;
    private float increment; //calculated amount to increment/decrement by
    private static float fill=0.0f;//fill amount
    private static int sectionNum = 0; //section number to enable/disable
    private List<GameObject> sections=new List<GameObject>();

    /*Section to do stuff when scene changes*/
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        prepareLevel();
    }
    /* End section*/

    // Use this for initialization
    void Start () {
        increment = 1.0f / numScenesInLevel;
    }

    //called after forward or back button is pressed and after scene number is updated
    public void updateProgress()
    {
        //set fill amount based on what scene number
        image.fillAmount = fill;
    }

    //prepares the level by loading gameobjects into list, setting them inactive
    public void prepareLevel()
    {
        fill = 0.0f;
        sectionNum = 0;
        sections.Clear();
        updateProgress();

        for (int i = 0; i < 13; i++)
        {
            sections.Add(GameObject.Find("" + i));
             sections[i].SetActive(false);
        }
        sections[sectionNum].SetActive(true);
    }

    /*Section to increment or decrement scene number according to which button was pressed*/
    public void nextScene()
    {
        if (sectionNum !=12)//if not last section
        {
            sections[sectionNum].SetActive(false);//disable
            sectionNum++;
            sections[sectionNum].SetActive(true);//enable

            fill += increment;
            updateProgress();
        }
        else //it's the last section
        {
            //save progress--later
            //load next scene/level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void prevScene()
    {
        if (fill > 0.0f)//if not first section
        {
            sections[sectionNum].SetActive(false);//disable
            sectionNum--;
            sections[sectionNum].SetActive(true);//enable

            fill -= increment;
            updateProgress();
        }
    }
}
