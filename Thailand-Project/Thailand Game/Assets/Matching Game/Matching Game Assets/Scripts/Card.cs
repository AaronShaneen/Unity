using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    //[HideInInspector]
    public int id;
    
    public Sprite cardBack;

    //[HideInInspector]
    public Sprite cardFront;

    public float flipSpeed = 4;

    private Image image;
    private Button button;

    private bool isFlippingOpen;
    private bool isFlippingClose;
    private bool flipped; //true show card front

    private float flippedAmount = 1;
    
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
	}

    //ONCLICK To flip card open
    public void FlipCard()
    {
        if(CardManager.instance.choice1 == 0)
        {
            CardManager.instance.choice1 = id;
            CardManager.instance.AddChosenCard(this.gameObject);

            isFlippingOpen = true;
            StartCoroutine(FlipOpen());

            button.interactable = false;
        }
        else if (CardManager.instance.choice2 == 0)
        {
            CardManager.instance.choice2 = id;
            CardManager.instance.AddChosenCard(this.gameObject);

            isFlippingOpen = true;
            StartCoroutine(FlipOpen());

            button.interactable = false;

            //Compare the cards
            StartCoroutine(CardManager.instance.CompareCards());
        }
    }

    //Open card over time
    IEnumerator FlipOpen()
    {
         while(isFlippingOpen && flippedAmount > 0)
        {
            flippedAmount -= Time.deltaTime * flipSpeed;
            flippedAmount = Mathf.Clamp01(flippedAmount);

            transform.localScale = new Vector3(flippedAmount, transform.localScale.y, transform.localScale.z);

            if(flippedAmount <= 0)
            {
                image.sprite = cardFront;
                isFlippingOpen = false;
                isFlippingClose = true; 

            }

            yield return null;
        }

        while (isFlippingClose && flippedAmount < 1)
        {
            flippedAmount += Time.deltaTime * flipSpeed;
            flippedAmount = Mathf.Clamp01(flippedAmount);

            transform.localScale = new Vector3(flippedAmount, transform.localScale.y, transform.localScale.z);

            if (flippedAmount >= 1)
            {
                isFlippingClose = false;

            }
            yield return null;
        }
    }

    //close the card over time
    IEnumerator FlipClose()
    {
        while (isFlippingOpen && flippedAmount > 0)
        {
            flippedAmount -= Time.deltaTime * flipSpeed;
            flippedAmount = Mathf.Clamp01(flippedAmount);

            transform.localScale = new Vector3(flippedAmount, transform.localScale.y, transform.localScale.z);

            if (flippedAmount <= 0)
            {
                image.sprite = cardBack;
                isFlippingOpen = false;
                isFlippingClose = true;

            }

            yield return null;
        }

        while (isFlippingClose && flippedAmount < 1)
        {
            flippedAmount += Time.deltaTime * flipSpeed;
            flippedAmount = Mathf.Clamp01(flippedAmount);

            transform.localScale = new Vector3(flippedAmount, transform.localScale.y, transform.localScale.z);

            if (flippedAmount >= 1)
            {
                isFlippingClose = false;

            }
            yield return null;
        }
        button.interactable = true;
    }

    //close the card
    public void CloseCard()
    {
        isFlippingOpen = true;
        StartCoroutine(FlipClose());
    }
}
