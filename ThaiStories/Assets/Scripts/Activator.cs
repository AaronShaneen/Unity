using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {
    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note;
    Color old;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Use this for initialization
    void Start () {
        old = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key))
            StartCoroutine(Pressed());

        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            AddScore();
            active = false;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Note" && Input.GetKeyDown(key))
            Destroy(collision.gameObject);
        note = collision.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
    }

    IEnumerator Pressed(){ 
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
