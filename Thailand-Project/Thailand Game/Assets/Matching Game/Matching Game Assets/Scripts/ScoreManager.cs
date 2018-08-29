using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    //Score
    public int currentScore;

    //Combos and turns
    private int currentComboAmount;

    private int currentTurn;

    //play Time
    public int playTime;
    private int seconds;
    private int minutes;

    [Header("Text Connections")]
    public Text timeText;
    public Text scoreText;
    public Text comboText;
    public Text turnsText;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {

        UpdateScoreText();

        StartCoroutine("PlayTime");
	}

    public void ResetCombo()
    {
        currentComboAmount = 0;
        currentTurn++;
        UpdateScoreText();
    }
    
    public void AddScore(int scoreAmount)
    {
        currentComboAmount++;
        currentTurn++;
        currentScore += scoreAmount * currentComboAmount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString("N");
        comboText.text = "Combo: " + currentComboAmount;
        turnsText.text = "Turns: " + currentTurn;
    }

    IEnumerator PlayTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playTime++;
            seconds = (playTime % 60);
            minutes = (playTime / 60) % 60;

            UpdateTime();
        }
    }

    void UpdateTime()
    {
        timeText.text = "Time: " + minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }

    public void StopTime()
    {
        StopCoroutine("PlayTime");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
