using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreActivityController : MonoBehaviour {

	[SerializeField]
	public List<GameObject> dialogObjects=new List<GameObject>();
	public List<GameObject> storyObjects=new List<GameObject>();
	private int objectCount = 0;
	
	// Use this for initialization
	void Start () {
		closeAllDialogs();
		closeAllStoryObjects();
		storyObjects[objectCount].SetActive(true); //set the first object active
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){			
			closeAllDialogs();
			Touch touch = Input.GetTouch(0);
			Vector2 touchPoint = Camera.main.ScreenToWorldPoint(touch.position);
			RaycastHit2D hit2D = Physics2D.Raycast( touchPoint, Vector2.zero);
			if(hit2D.collider !=null)
			{
				GameObject character = hit2D.transform.gameObject;
				StartCoroutine(sequenceDialogs(character));
			}
			objectCount++;
			if (objectCount < storyObjects.Count)
			{
				storyObjects[objectCount].SetActive(true);
			}		
		}
	}

	void closeAllDialogs()
	{
		foreach (GameObject o in dialogObjects)
		{
			o.gameObject.SetActive(false);
		}
	}

	void closeAllStoryObjects()
	{
		foreach (GameObject o in storyObjects)
		{
			o.SetActive(false);
		}
	}

	IEnumerator sequenceDialogs(GameObject character)
	{		
		
		Transform descriptObject = character.transform.GetChild(0);
		Transform descriptObjectText = descriptObject.transform.GetChild(1);
		AudioSource descriptAudio = descriptObjectText.GetComponentInChildren<AudioSource>();
		
		Transform dialogObject = character.transform.GetChild(1);	
		Transform dialogObjectText = dialogObject.transform.GetChild(1);
		AudioSource dialogAudio = dialogObjectText.GetComponentInChildren<AudioSource>();
		
		descriptObject.gameObject.SetActive(true);
		descriptAudio.Play();
		yield return new WaitForSeconds(descriptAudio.clip.length);

		dialogObject.gameObject.SetActive(true);
		dialogAudio.Play();
		yield return new WaitForSeconds(dialogAudio.clip.length);
	}
}
